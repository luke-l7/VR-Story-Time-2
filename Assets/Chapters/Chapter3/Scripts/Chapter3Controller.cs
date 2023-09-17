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

    private FMOD.Studio.EventInstance dialogueInstance;
    private FMOD.Studio.EventInstance ambienceInstance;

    bool coroutineRunning = false;
    bool oneTimeCoroutine = false;

    int stage = 0;

    // Start is called before the first frame update
    void Start()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/night with hooting");
        ambienceInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        //melody walking towards tree
        if (stage == 0 && Vector3.Distance(melody.transform.position, owl.transform.position) < 8f)
        {
            stage++;
        }
        //owl talks to melody
        else if (stage == 1)
        {
            melody.GetComponent<MelodyScene3>().stopWalking();
            owl.GetComponent<Animator>().SetBool("Talking", true);
            ambienceInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/night without hooting");
            ambienceInstance.start();
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter3");
            StartCoroutine(waitSecondsAndPlayEvent(2, dialogueInstance));
            coroutineRunning= true;
            stage++;
        }
        else if (!coroutineRunning && stage == 2)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            dialogueInstance.getPlaybackState(out state);
            //chapter audio finished playing
            if (!oneTimeCoroutine && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
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
        //fade back to bedroom
        if(stage == 3)
        {
            SceneLoadClass.SceneBackFrom = 3;
            ScreenFader.Instance.FadeTo(1);
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
