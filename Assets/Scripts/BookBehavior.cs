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
    private bool isBookOpen;

    Animator bookAnim;
    private bool playedHoveringAnimation = false;

    private void Awake()
    {
        //make sure the book is closed at the start
        book.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.ClosedFront, 0f);

    }
    void Start()
    {
        //bookAnim = GetComponent<Animator>();
        bookAnim = book.GetComponent<Animator>();
        shouldMove = false;
        isBookOpen= false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsInteracting())
        //{
        //    // Call the pointing detection method
        //    OnPointingDetected();
        //}
        if(shouldMove) { moveBook(); }

        if (!isBookOpen && bookAnim.GetBool("DoneHovering") == true)
        {
            openBook();
        }
    }

    public void moveBook()
    {
        shouldMove= false;
        bookAnim.SetBool("shouldHover", true);
    }

    public void openBook()
    {
        isBookOpen= true;
        playedHoveringAnimation = true;
        book.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 3f);
        bookAnim.SetBool("shouldHover", false);
    }
}

