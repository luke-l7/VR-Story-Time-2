using echo17.EndlessBook;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookBehavior : MonoBehaviour
{
    public Transform Player;
    public bool shouldMove;
    private Animator bookAnim;
    private AudioManager audioManager;
    public ParticleSystem runesParticleSystem;
    public RoomTeddy roomTeddy;

    // play pages params
    private FMOD.Studio.EventInstance fmod_instance;
    public bool RequestedPlay;
    private int start;
    private int end;

    private bool playedHoveringAnimation = false;

    private void Awake()
    {
        //make sure the book is closed at the start
        GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.ClosedFront, 0f);
    }
    void Start()
    {
        //bookAnim = GetComponent<Animator>();
        shouldMove = false;
        bookAnim = GetComponent<Animator>();
        audioManager = AudioManager.Instance;
        RequestedPlay = false;
        runesParticleSystem.Stop();

        if(SceneLoadClass.SceneBackFrom != 0) // if back from scene
        {
            GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 0f);
            bookAnim.SetBool("backFromScene", true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        // for debugging
        if(shouldMove) { moveBook(); }

        FMOD.Studio.PLAYBACK_STATE state;
        fmod_instance.getPlaybackState(out state);
        // play pages routine - when a scene script requests its pages the book plays and narrates them accordingly
        if (RequestedPlay && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            GetComponent<EndlessBook>().TurnToPage(start, EndlessBook.PageTurnTimeTypeEnum.TimePerPage, 3f); // flip to start page
            //some pages have no audio in it (like picture pages) and so to keep thr fmod naming convention ignore these pages for audio
            try
            {
                fmod_instance = FMODUnity.RuntimeManager.CreateInstance("event:/page_" + start.ToString()); // the event corresponding to the page is always names page_ + no of page in FMOD
                fmod_instance.start();
                UnityEngine.Debug.Log("event:/page_" + start.ToString());
                
            }
            catch 
            {
                UnityEngine.Debug.Log($"audio-less page, start = {start}, end = {end}");
            }
            start++;
        }
        if (start > end) { RequestedPlay = false; }
    }

    public void moveBook()
    {
        bookAnim.SetBool("shouldHover", true);
        roomTeddy.Dance();
        audioManager.ActivateBookSound();
        runesParticleSystem.Stop();
    }
    public void openBook()
    {
        playedHoveringAnimation = true;
        GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 5f);
        bookAnim.SetBool("shouldHover", false);
    }

    public void playPages(int start, int end)
    {
        RequestedPlay = true;
        this.start = start;
        this.end = end;
    }

    public void ActivateSceneAnimation()
    {
        bookAnim.SetBool("startScene", true);
    }

    public void closeBook()
    {
        GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.ClosedBack, 5f);
    }
}

