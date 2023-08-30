using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class MelodyCh1 : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    Ch1AudioManager audioManager;
    public GameObject waypoints;
    public Transform[] waypointsArr;
    private StoryCanvas storyCanvas;
    public bool shouldWait = true;
    bool startedCoroutine = false;
    bool coroutineRunning = false;
    bool parrotAnswered = false;
    bool melodyWondered= false;
    bool readyToHop = false;
    int stage = 0;
    private string ch1_2_path = "event:/ch1_2";
    private string ch1_3_path = "event:/ch1_3";
    private string ch1_4_path = "event:/ch1_4";
    private string ch1_5_path = "event:/ch1-5";

    List<string> paths;

    public static MelodyCh1 Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    enum CurrState
    {
        waitingForPlayer,
        goingToMarket,
        withParrot
        
    }
    CurrState currState = CurrState.waitingForPlayer;

    void Start()
    {
        audioManager = Ch1AudioManager.Instance;
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
        paths = new List<string> { ch1_2_path, ch1_3_path,ch1_4_path, ch1_5_path};
        animator= GetComponent<Animator>();
        animator.SetBool("Walk", true);
        agent = GetComponent<NavMeshAgent>();
        storyCanvas = StoryCanvas.Instance;
        GoToMarket();
    }

    void Update()
    {
        //waiting by mill
        if(currState== CurrState.waitingForPlayer)
        {
            agent.SetDestination(waypointsArr[0].position);
            if(Vector3.Distance(transform.position, waypointsArr[0].position) < 0.4f)
            {
                animator.SetBool("Walk", false);
            }
            if (!shouldWait)
            {
                currState = CurrState.goingToMarket;
                animator.SetBool("Walk", true);
                audioManager.PlayOneTimeSound(ch1_2_path);
                storyCanvas.ChangeText();
            }
        }
        //going to market
        else if (currState == CurrState.goingToMarket)
        {
            if (Vector3.Distance(transform.position, waypointsArr[1].position) > 0.4f)
            {
                GoToMarket();
            }
            else
            {
                currState = CurrState.withParrot;
                animator.SetBool("Walk", false);
            }
        }
        //parrot convo
        else if (currState == CurrState.withParrot)
        {
            Debug.Log(stage);
            if (!startedCoroutine && stage == 0)
            {
                startedCoroutine = true;
                StartCoroutine(waitSecondsAndPlay(2, paths[1]));
                coroutineRunning= true;
            }
            //parrot stops making commotion
            if(!coroutineRunning && !parrotAnswered && stage==1)
            {
                approachParrot();
                coroutineRunning = true ;
                StartCoroutine(waitSecondsAndPlay(7, paths[2]));
                Parrot.stopMakingCommotion();
                parrotAnswered = true;
            }
            //melody asks parrot
            else if (!coroutineRunning && !melodyWondered && stage == 2)
            {
                melodyWondered= true;
                coroutineRunning= true;
                StartCoroutine(waitSecondsAndPlay(7, paths[3]));
            }
            //echo hops from house to house
            else if(!coroutineRunning && !readyToHop && stage ==3)
            {
                Parrot.HopHouseToHouse();

            }

        }
    }
    public void GoToMarket()
    {
        agent.SetDestination(waypointsArr[1].position);
    }
    IEnumerator waitSecondsAndPlay(int seconds, string path)
    {
        yield return new WaitForSeconds(seconds);
        audioManager.PlayOneTimeSound(path);
        storyCanvas.ChangeText();

        coroutineRunning = false;
        stage++;
    }
    private void approachParrot()
    {
        Debug.Log("approach parrot");
        agent.SetDestination(waypointsArr[2].position);
        //Ch1AudioManager.Instance.PlayOneTimeSound(paths[2]);
    }
}
