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
    private string ch1_2_path = "event:/Chapter1_2";
    private string ch1_3_path = "event:/ch1_3";
    private string ch1_4_path = "event:/ch1_4";
    private string ch1_5_path = "event:/ch1-5";
    private FMOD.Studio.EventInstance fmod_instance;

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
        withParrot,
        preFlute

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
        FMOD.Studio.PLAYBACK_STATE state;
        fmod_instance.getPlaybackState(out state);
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
            coroutineRunning = true;
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
        if(stage==2 && !coroutineRunning && currState == CurrState.withParrot)
        {
            coroutineRunning = true;
            StartCoroutine(waitSecondsAndRaiseFlute(12));
            currState = CurrState.preFlute;
            stage++;
        }
        if(stage == 3 && !coroutineRunning && currState == CurrState.preFlute)
        {
            StartCoroutine(waitSecondsAndPlay(12, ch1_2_path));
            stage++;
        }
    }
    IEnumerator waitSecondsAndHop(int seconds)
    {

        yield return new WaitForSeconds(seconds);
        coroutineRunning = false;
        Parrot.HopHouseToHouse();
    }
    IEnumerator waitSecondsAndRaiseFlute(int seconds)
    {

        yield return new WaitForSeconds(seconds);
        coroutineRunning = false;
        animator.SetTrigger("RaiseFlute");
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
