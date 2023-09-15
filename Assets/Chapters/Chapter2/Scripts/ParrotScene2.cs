using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotScene2 : MonoBehaviour
{
    Animator animator;
    public static ParrotScene2 Instance { get; private set; }

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
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }


    public void ToggleWalk()
    {
        bool walking = animator.GetBool("Walk");
        animator.SetBool("Walk", !walking);
    }
}
