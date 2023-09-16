using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene4 : MonoBehaviour
{
    public GameObject waypoints;
    public Transform[] waypointsArr;
    public static MelodyScene4 Instance { get; private set; }

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

    }
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
   

    // Update is called once per frame
    void Update()
    {
    }
}
