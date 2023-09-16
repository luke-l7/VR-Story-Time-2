using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScene3 : MonoBehaviour
{
    Animator animator ;
    public static TurtleScene3 Instance { get; private set; }

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
    public void ToggleWalk()
    {
        bool walking = animator.GetBool("Walk");
        animator.SetBool("Walk", !walking);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
