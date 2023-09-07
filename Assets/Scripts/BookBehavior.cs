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
    public GameObject book;
    private Animator bookAnim;
    private AudioManager audioManager;
    public ParticleSystem runesParticleSystem;


    // play pages params
    private FMOD.Studio.EventInstance fmod_instance;
    private bool RequestedPlay;
    private int start;
    private int end;

    private bool playedHoveringAnimation = false;

    private void Awake()
    {
        //make sure the book is closed at the start
        book.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.ClosedFront, 0f);
    }
    void Start()
    {
        //bookAnim = GetComponent<Animator>();
        shouldMove = false;
        bookAnim = book.GetComponent<Animator>();
        audioManager = AudioManager.Instance;
        RequestedPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsInteracting())
        //{
        //    // Call the pointing detection method
        //    OnPointingDetected();
        //}

        // for debugging
        if(shouldMove) { moveBook(); }

        FMOD.Studio.PLAYBACK_STATE state;
        fmod_instance.getPlaybackState(out state);
        // play pages routine - when a scene script requests its pages the book plays and narrates them accordingly
        if (RequestedPlay && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            book.GetComponent<EndlessBook>().TurnToPage(start, EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime, 1f); // flip to start page
            fmod_instance = FMODUnity.RuntimeManager.CreateInstance("event:/page_" + start.ToString()); // the event corresponding to the page is always names page_ + no of page in FMOD
            fmod_instance.start();
            start++;
        }
        if(start > end) { RequestedPlay = false; }
    }

    public void moveBook()
    {
        bookAnim.SetBool("shouldHover", true);
        audioManager.ActivateBookSound();
        runesParticleSystem.Stop();
    }
    public void openBook()
    {
        playedHoveringAnimation = true;
        book.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 3f);
        bookAnim.SetBool("shouldHover", false);
    }

    public void playPages(int start, int end)
    {
        RequestedPlay = true;
        this.start = start;
        this.end = end;
    }
}

