using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MelodyScene2 : MonoBehaviour
{
    public GameObject waypoints;
    public Transform[] waypointsArr;
    public static MelodyScene2 Instance { get; private set; }

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
        ParrotScene2.Instance.ToggleWalk();
    }

    // Update is called once per frame
    void Update()
    {
            
        agent.SetDestination(waypointsArr[0].position);
        
    }
    public void stopWalking()
    {
        animator.SetBool("Walk", false);
        ParrotScene2.Instance.ToggleWalk();


    }
}
