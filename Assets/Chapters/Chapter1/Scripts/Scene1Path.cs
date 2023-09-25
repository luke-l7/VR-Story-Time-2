using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Path : MonoBehaviour
{
    public Transform[] waypoints;
    private void Awake()
    {
        Transform path = transform.GetChild(0);
        waypoints = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform[] GetPath()
    {
        return waypoints;
    }
}
