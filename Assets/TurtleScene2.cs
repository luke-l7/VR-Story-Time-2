using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScene2 : MonoBehaviour
{
    Animator animator;
    public static TurtleScene2 Instance { get; private set; }

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
        animator = GetComponent<Animator>();

    }
    
    public void PlayHappyAnimation()
    {
        animator.SetBool("Happy", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
