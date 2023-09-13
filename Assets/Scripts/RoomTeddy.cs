using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeddy : MonoBehaviour
{
    private Animator animator;
    private string bookHint1 = "Dont you think that book over by the window looks suspicios?";
    private string bookHint2 = "Maybe try extending your hand to it?";
    private string bookCheer = "How Magical!";
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
        animator = GetComponent<Animator>();
    }

    public void StandUp()
    {
        animator.SetTrigger("StandUp");
        FMODUnity.RuntimeManager.PlayOneShot("event:/teddy_bear_hint_1");
        popupSystem.ShowPopUp(bookHint1);
    }

    public void GiveAnotherHint()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/teddy_bear_hint_2");
        popupSystem.ShowPopUp(bookHint2);
    }

    public void CheerSpeech() // changes teddy popup to a cheer
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/teddy_bear_cheer");
        popupSystem.ShowPopUp(bookCheer);
    }
}
