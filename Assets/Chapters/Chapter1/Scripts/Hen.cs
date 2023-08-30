using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hen : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Waypoints;
    public Transform[] waypointsArr;
    Animator animator;
    int currWpId = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypointsArr = new Transform[Waypoints.transform.childCount];
        for (int i = 0; i < Waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = Waypoints.transform.GetChild(i);
        }
        agent= GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, waypointsArr[currWpId].position) < 0.2f)
        {
            currWpId = currWpId >= waypointsArr.Length ? waypointsArr.Length-1 : currWpId+1 ;
        }
        agent.SetDestination(waypointsArr[currWpId].position);
        if(currWpId == waypointsArr.Length - 1)
        {
            animator.enabled= false;
        }
    }
}
