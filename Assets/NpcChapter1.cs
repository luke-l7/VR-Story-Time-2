using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcChapter1 : MonoBehaviour
{
    public Path pathObj;
    public int currWpIndex;
    Transform[] path;
    NavMeshAgent agent;

    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        path = pathObj.GetPath();
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && path != null)
        {
            if(Vector3.Distance(transform.position, path[currWpIndex].position) < 1f)
            {
                //if reached end of path destroy self
                if(currWpIndex == path.Length-1)
                {
                    Destroy(gameObject);
                    this.enabled= false; //for some reason the script is still 
                    active= false;
                }
                //proceed to the next wp
                else
                {
                    currWpIndex++;
                }
            }
            if (active)
            {
                agent.SetDestination(path[currWpIndex].position);
            }
        }
    }

    public void SetPath(Path path)
    {
        pathObj = path; 
    }
}
