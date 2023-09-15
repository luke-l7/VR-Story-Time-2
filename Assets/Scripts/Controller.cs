using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AzureSky;

public class Controller : MonoBehaviour
{
    public GameObject book;
    public GameObject cameraObj;
    public GameObject skybox;
    public GameObject bookHoverButton;

    private BookBehavior bookBehavior;
    private BloomEffect cameraBehavior;

    private AzureTimeController timeController;
    private bool speedUpTime;
    public ParticleSystem runesParticleSystem;
    private Animator bookAnim;
    // time before teddy stands up
    private float time_passed;
    private int NO_OF_SECONDS = 60;
    //debug
    public bool SwitchScene = false;
    public bool teddyStandUp = false;


    private void Start()
    {
        runesParticleSystem.Stop();
        speedUpTime = false;
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        timeController = skybox.GetComponent<AzureTimeController>();
        if (SceneLoadClass.SceneToLoad == 0)
        {
            time_passed = 0.0f;
            bookAnim = book.GetComponent<Animator>();
            // activate teddy stand up and book interaction after NO_OF_SECONDS - see ActivateTeddyInteraction function below.
            Invoke("ActivateTeddyInteraction", NO_OF_SECONDS);
        }
        else // return Scene to previous state
        {
            // teddy is up with cheerSpeech
            RoomTeddy.Instance.StandUp();
            RoomTeddy.Instance.CheerSpeech();
            // book is back to playing state
            bookBehavior.openBook();
            bookAnim.SetBool("backFromScene", true);

            switch(SceneLoadClass.SceneToLoad)
            {
                case 1: GetComponent<Scene2>().enabled = true; break; // back from scene1, activate scene2
                //case 2: GetComponent<Scene3>().enabled = true; break;
                //case 3: GetComponent<Scene4>().enabled = true; break;
                //case 4: GetComponent<Scene5>().enabled = true; break;
            }
        }


    }
    void Update()
    {   
        Vector2 currTime = timeController.GetTimeOfDay();
        time_passed += Time.deltaTime;
        float minutes = (int)time_passed / 60;
        

        //transition time to 19:00 to set up the scene
        if(currTime.x < 18 || (currTime.x > 18 && currTime.y < 5))
        {
            UnityEngine.Debug.Log("time speeding");
            timeController.StartTimelineTransition(18, 5, 20f, AzureTimeDirection.Forward);

        }


        //debug purposes

        if (SwitchScene)
        {
            transitionToScene();
            //SceneController.Instance.TransitionToScene(3);
        }
        if (teddyStandUp)
        {
            ActivateTeddyInteraction();
        }

        // if book animation is done, it's time for Scene 1 to be activated!
        if (bookAnim.GetBool("DoneHovering") == true)
        {
            GetComponent<WelcomeScript>().enabled = true;
            this.enabled = false;
        }
    }


    /**
     * activates the ability of extending the hand for the book - happens after 1 minute and after the teddy's hint
     * this function is set to be invoked after 1 minute in Start();
     */
    private void ActivateTeddyInteraction() 
    {
        bookHoverButton.SetActive(true);
        RoomTeddy.Instance.StandUp();
        runesParticleSystem.Play();
        Invoke("GiveSecondHint", 30); // invoke give another hint after 30 seconds - in total 1.5 mins after teddy stands up and book not touched

    }


    /**
     * if the book haven't been touched after the bear's hint in 30 seconds, a second hint is applied that asks the player to try and extend a hand towards it
     * this function is invoked automatically after 30 seconds using the "Invoke" in the previous function
     */
    private void GiveSecondHint()
    {
        if(bookHoverButton.activeSelf) // if book is still not touched
        {
            RoomTeddy.Instance.GiveAnotherHint();
        }
    } 
    /**
     * activate book animation and then fade out to story scene
     */
    private void transitionToScene()
    {
        //activate book animation

        bookBehavior.ActivateSceneAnimation();
        AudioManager.Instance.StopMainMusic();
        ScreenFader.Instance.FadeTo(3);

    }
}
