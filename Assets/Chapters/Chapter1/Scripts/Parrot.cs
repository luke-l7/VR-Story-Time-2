using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour
{
    static Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void stopMakingCommotion()
    {
        animator.SetBool("makeCommotion", false);
    }
    public static void HopHouseToHouse()
    {
        animator.SetBool("shouldHop", true);
    }
}
