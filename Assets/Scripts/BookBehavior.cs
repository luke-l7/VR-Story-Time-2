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
                transform.position = Player.transform.position + new Vector3(0,0,0.8f);
                transform.Rotate( -90f, 8.055f, 0f);
                //transform.LookAt(Player.position);
            }
        }
    }
}

