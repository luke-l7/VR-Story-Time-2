using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public Transform wp;
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();    
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(wp.position);
        if(Vector3.Distance(transform.position, wp.position) < 1f)
        {
            //activate idle animation
            Debug.Log("dancin");
            animator.SetBool("Move", false);
        }
    }
}
