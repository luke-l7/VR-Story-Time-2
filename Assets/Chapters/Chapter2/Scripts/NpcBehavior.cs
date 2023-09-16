using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcBehavior : MonoBehaviour
{
    public int nextWaypointIndex;
    public GameObject waypoints;
    public Transform[] waypointsArr;

    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        waypointsArr = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < waypoints.transform.childCount; i++)
        {
            waypointsArr[i] = waypoints.transform.GetChild(i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, waypointsArr[nextWaypointIndex].position) < 2f)
        {
            nextWaypointIndex = nextWaypointIndex >= waypointsArr.Length - 1? 0 : nextWaypointIndex + 1;
        }
        agent.SetDestination(waypointsArr[nextWaypointIndex].position);

    }
}
