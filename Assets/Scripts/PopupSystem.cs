using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PopupSystem : MonoBehaviour
{

    public TMP_Text PopupText;
    public Animator animator;

    private void Start()
    {
        //animator = gameObject.GetNamedChild("Popup").GetComponent<Animator>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        PopupText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        //PopupText = gameObject.GetNamedChild("Popup").GetNamedChild("Text").GetComponent<TextMeshProUGUI>();
    }
    public void ShowPopUp(string text)
    {
        gameObject.SetActive(true);
        animator.SetTrigger("Pop");
        PopupText.text = text;
        //optional audio can be added here
    }

}
