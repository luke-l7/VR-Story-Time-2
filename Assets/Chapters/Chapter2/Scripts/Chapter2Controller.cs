using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Chapter2Controller : MonoBehaviour
{
    public GameObject melody;
    public GameObject parrot;
    public GameObject turtle;
    public GameObject fluteObj;
    public bool DonePlayingFlute = false;

    private FMOD.Studio.EventInstance audioInstance;
    bool coroutineRunning = false;
    bool oneTimeCoroutine = false;

    int stage = 0;
    enum GameState
    {
        WalkingToTurutle,
        TurtleConvo
    }
    GameState currState = GameState.WalkingToTurutle;


    // Update is called once per frame
    void Update()
    {
        //melody walking towards turtle
        if(currState == GameState.WalkingToTurutle && Vector3.Distance(melody.transform.position, turtle.transform.position) < 7f)
        {
            currState= GameState.TurtleConvo;
            stage++;
        }
        //melody starts talking to turtle
        else if (stage == 1 && currState == GameState.TurtleConvo ) 
        {
            melody.GetComponent<MelodyScene2>().stopWalking();
            audioInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter2_1");
            audioInstance.start();
            stage++;
        }
        
        else if(stage == 2)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            audioInstance.getPlaybackState(out state);
            //melody stopped thinking and about to play flute
            if (!oneTimeCoroutine && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                StartCoroutine(waitSecondsAndPlayOneShot(2, "event:/before_flute_interact"));
                fluteObj.SetActive(true);
                oneTimeCoroutine= true;
            }
            //make melody and parrot look at turtle
            Vector3 direction = turtle.transform.position - melody.transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                melody.transform.rotation = Quaternion.LookRotation(direction);
                parrot.transform.rotation = Quaternion.LookRotation(direction);
            }
            if (DonePlayingFlute)
            {
                StartCoroutine(waitSecondsAndPlayOneShot(1, "event:/good_job"));
                TurtleScene2.Instance.PlayHappyAnimation();

                stage++;
            }
        }
        else if(stage==3)
        {
            audioInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter2_2");
            StartCoroutine(waitSecondsAndPlayEvent(8, audioInstance));

            stage++;
        }
        
        
    }
    IEnumerator waitSecondsAndPlayOneShot(int seconds, string path)
    {
        yield return new WaitForSeconds(seconds);
        RuntimeManager.PlayOneShot(path);
        coroutineRunning= false;
    }
    IEnumerator waitSecondsAndPlayEvent(int seconds, FMOD.Studio.EventInstance audioEvent)
    {
        yield return new WaitForSeconds(seconds);
        audioEvent.start();
        coroutineRunning = false;
    }
}
