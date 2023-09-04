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
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsInteracting())
        //{
        //    // Call the pointing detection method
        //    OnPointingDetected();
        //}
        if (!playedHoveringAnimation)
        {
            if (shouldMove)
            {
                bookAnim.SetBool("shouldHover", true);

            }

            if (bookAnim.GetBool("DoneHovering") == true)
            {
                playedHoveringAnimation=true;
                //Debug.Log("done hovering");
                book.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenFront, 3f);
                bookAnim.SetBool("shouldHover", false);
                // set its coords the same as when the animation stops, so no jump happens
                book.transform.position = new Vector3(2.39197326f, 0.148902416f, -5.85163689f);
                book.transform.Rotate(271.488831f, 355.424011f, 14.4269972f);
                //transform.LookAt(Player.position);
            }
        } 
    }
}

