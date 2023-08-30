using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeddy : MonoBehaviour
{
    public Animator animator;
    private string bookHint1 = "dont you think that book over by the window looks suspicios?";
    public static RoomTeddy Instance { get; private set; }
    public PopupSystem popupSystem;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
        void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void StandUp()
    {

        animator.SetTrigger("StandUp");
        popupSystem.ShowPopUp(bookHint1);
    }
}
