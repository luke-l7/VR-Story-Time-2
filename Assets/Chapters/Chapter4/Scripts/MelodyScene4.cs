using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene4 : MonoBehaviour
{
    public static MelodyScene4 Instance { get; private set; }
    public GameObject book;

    NavMeshAgent agent;
    Animator animator;

    bool lookAtBook = false;
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

        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
   

    // Update is called once per frame
    void Update()
    {
        if(lookAtBook)
        {
            Vector3 direction = book.transform.position - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
    public void LookAtBook()
    {
        lookAtBook= true;
    }
}
