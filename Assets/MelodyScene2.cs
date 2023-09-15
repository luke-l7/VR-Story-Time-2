using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene2 : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public GameObject waypoints;
    public Transform[] waypointsArr;
    public static MelodyScene2 Instance { get; private set; }

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
        agent = GetComponent<NavMeshAgent>();
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(waypointsArr[0].position);
        
    }
}
