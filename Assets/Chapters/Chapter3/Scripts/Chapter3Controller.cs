using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MelodyScene1;
using UnityEngine.XR.Interaction.Toolkit;
using FMODUnity;

public class Chapter3Controller : MonoBehaviour
{
    public GameObject melody;
    public GameObject parrot;
    public GameObject turtle;
    public GameObject owl;

    private FMOD.Studio.EventInstance audioInstance;
    bool coroutineRunning = false;
    bool oneTimeCoroutine = false;

    int stage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //melody walking towards tree
        if (stage == 0 && Vector3.Distance(melody.transform.position, owl.transform.position) < 8f)
        {
            stage++;
        }
        else if (stage == 1)
        {
            melody.GetComponent<MelodyScene3>().stopWalking();
            audioInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter3");
            waitSecondsAndPlayEvent(2, audioInstance);
            coroutineRunning= true;
            stage++;
        }
        else if (!coroutineRunning && stage == 2)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            audioInstance.getPlaybackState(out state);
            //melody stopped thinking and about to play flute
            if (!oneTimeCoroutine && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                //what to do when finished playing
                stage++;
            }
            //make melody parrot and turtle look at owl
            Vector3 direction = owl.transform.position - melody.transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                melody.transform.rotation = Quaternion.LookRotation(direction);
                parrot.transform.rotation = Quaternion.LookRotation(direction);
                turtle.transform.rotation = Quaternion.LookRotation(direction);
            }
            
        }
    }
    IEnumerator waitSecondsAndPlayOneShot(int seconds, string path)
    {
        yield return new WaitForSeconds(seconds);
        RuntimeManager.PlayOneShot(path);
    }
    IEnumerator waitSecondsAndPlayEvent(int seconds, FMOD.Studio.EventInstance audioEvent)
    {
        yield return new WaitForSeconds(seconds);
        audioEvent.start();
        coroutineRunning = false;
    }
}
