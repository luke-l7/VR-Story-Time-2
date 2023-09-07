using echo17.EndlessBook;
using System.Collections;
using System.Collections.Generic;
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
        book.GetComponent<EndlessBook>().TurnToPage(start, EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime, 1f);

    }
}

