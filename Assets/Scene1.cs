using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public int StartPage;
    public int EndPage;
    public BookBehavior BookBehaviorObj;

    // narrator voice events
    string[] events_sequence;
    void Start()
    {
        BookBehaviorObj.playPages(StartPage,EndPage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
