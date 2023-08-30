using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class Controller : MonoBehaviour
{
    public GameObject book;
    public GameObject cameraObj;
    public GameObject skybox;

    private BookBehavior bookBehavior;
    private BloomEffect cameraBehavior;
    public GameObject runes;
    private ParticleSystem runesParticleSystem;
    private AzureTimeController timeController;
    private bool speedUpTime;
    private bool runesStartedPlaying;
    private AudioManager audioManager;

    //debug
    public bool SwitchScene = false;
    public bool teddyStandUp = false;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        runesParticleSystem = runes.GetComponent<ParticleSystem>();
        runesParticleSystem.Stop();
        runesStartedPlaying = false;

        speedUpTime = false;
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        timeController= skybox.GetComponent<AzureTimeController>();

    }
    void Update()
    {   
        Vector2 currTime = timeController.GetTimeOfDay();

        if (bookBehavior.shouldMove)
        {

            audioManager.ActivateBookSound();
            runesParticleSystem.Stop();
        }

        //activate it after 8 pm if player hadnt called for book
        else if(currTime.x >= 18f || currTime.x < 4f)
        {

            if (!runesStartedPlaying)
            {
                runesParticleSystem.Play();
                runesStartedPlaying = true;
            }
        }
        //transition time to 19:00 to set up the scene
        else if(currTime.x < 18 || (currTime.x > 18 && currTime.y < 5)) {
            Debug.Log("time speeding");
            timeController.StartTimelineTransition(18, 5, 20f, AzureTimeDirection.Forward);

        }


        //debug purposes

        if (SwitchScene)
        {
            //SceneController.Instance.TransitionToScene(3);
            ScreenFader.Instance.FadeTo(3);
        }
        if (teddyStandUp)
        {
            RoomTeddy.Instance.StandUp();
        }
    }


    
}
