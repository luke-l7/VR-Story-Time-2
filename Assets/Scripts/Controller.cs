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
    public GameObject bookHoverButton;

    private BookBehavior bookBehavior;
    private BloomEffect cameraBehavior;

    private AzureTimeController timeController;
    private bool speedUpTime;
    private bool runesStartedPlaying;
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
        runesStartedPlaying = false;

        speedUpTime = false;
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        timeController= skybox.GetComponent<AzureTimeController>();

        time_passed = 0.0f;

        bookAnim = book.GetComponent<Animator>();

        // activate teddy stand up and book interaction after NO_OF_SECONDS - see ActivateTeddyInteraction function below.
        Invoke("ActivateTeddyInteraction", NO_OF_SECONDS); 

    }
    void Update()
    {   
        Vector2 currTime = timeController.GetTimeOfDay();
        time_passed += Time.deltaTime;
        float minutes = (int)time_passed / 60;
        

        if (bookBehavior.shouldMove)
        {
           
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
        else if(currTime.x < 18 || (currTime.x > 18 && currTime.y < 5))
        {
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
}
