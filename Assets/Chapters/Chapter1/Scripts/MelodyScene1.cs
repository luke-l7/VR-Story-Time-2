using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene1 : MonoBehaviour
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
    bool melodyWondered = false;
    bool readyToHop = false;
    int stage = 0;
    private string ch1_2_path = "event:/ch1_1";
    private string ch1_3_path = "event:/ch1_3";
    private string ch1_4_path = "event:/ch1_4";
    private string ch1_5_path = "event:/ch1-5";

    List<string> paths;

    public static MelodyScene1 Instance { get; private set; }

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
        approachingParrot,
        withParrot

    }
    CurrState currState = CurrState.approachingParrot;

    void Start()
    {
        audioManager = Ch1AudioManager.Instance;
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
        paths = new List<string> { ch1_2_path, ch1_3_path, ch1_4_path, ch1_5_path };
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
        agent = GetComponent<NavMeshAgent>();
        storyCanvas = StoryCanvas.Instance;
        approachParrot();
    }

    void Update()
    {
        //if arrived to parrot waypoint switch state
        if (currState == CurrState.approachingParrot && Vector3.Distance(waypointsArr[0].position, transform.position) < 1f)
        {
            currState = CurrState.withParrot;
            stage++;
        }
        //parrot convo
        if ( stage == 1 && currState == CurrState.withParrot)
        {
            animator.SetBool("Walk", false) ;
            Parrot.stopMakingCommotion();
            StartCoroutine(waitSecondsAndHop(10));
            stage++;

            //Parrot.HopHouseToHouse();

            //if (!startedCoroutine && stage == 0)
            //{
            //    startedCoroutine = true;
            //    StartCoroutine(waitSecondsAndPlay(2, paths[1]));
            //    coroutineRunning = true;
            //}
            ////parrot stops making commotion
            //if (!coroutineRunning && !parrotAnswered && stage == 1)
            //{
            //    approachParrot();
            //    coroutineRunning = true;
            //    StartCoroutine(waitSecondsAndPlay(7, paths[2]));
            //    Parrot.stopMakingCommotion();
            //    parrotAnswered = true;
            //}
            ////melody asks parrot
            //else if (!coroutineRunning && !melodyWondered && stage == 2)
            //{
            //    melodyWondered = true;
            //    coroutineRunning = true;
            //    StartCoroutine(waitSecondsAndPlay(7, paths[3]));
            //}
            ////echo hops from house to house
            //else if (!coroutineRunning && !readyToHop && stage == 3)
            //{
            //    Parrot.HopHouseToHouse();

            //}

        }
    }
    IEnumerator waitSecondsAndHop(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Parrot.HopHouseToHouse();
        stage++;
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
        Debug.Log("approaching parrot");
        agent.SetDestination(waypointsArr[0].position);
        //Ch1AudioManager.Instance.PlayOneTimeSound(paths[2]);
    }
}
