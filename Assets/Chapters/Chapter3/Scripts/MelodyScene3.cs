using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene3 : MonoBehaviour
{
    public GameObject waypoints;
    public Transform[] waypointsArr;
    public static MelodyScene3 Instance { get; private set; }

    NavMeshAgent agent;
    Animator animator;

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
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
        ParrotScene2.Instance.ToggleWalk();
        TurtleScene3.Instance.ToggleWalk();
    }
    public void stopWalking()
    {
        animator.SetBool("Walk", false);
        ParrotScene2.Instance.ToggleWalk();
        TurtleScene3.Instance.ToggleWalk();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(waypointsArr[0].position);
    }
}
