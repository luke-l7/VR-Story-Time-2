using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScript : MonoBehaviour
{
    public FMODUnity.EventReference welcome_speech;
    public GameObject Book; // to open book once welcome speech is finished

    private FMOD.Studio.EventInstance fmod_instance;
    void Start()
    {
        // play welcome speech with FMOD
        fmod_instance = FMODUnity.RuntimeManager.CreateInstance(welcome_speech.Guid); // Guid returns name of event chosen from editor GUI
        fmod_instance.start();
    }


    void Update()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        fmod_instance.getPlaybackState(out state);
        if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED) // if speech has stopped
        {
            Book.GetComponent<BookBehavior>().openBook(); // open book
            GetComponent<Scene1>().enabled = true; // turn on Scene 1
            this.enabled = false; // turn this script off
        }
    }
}
