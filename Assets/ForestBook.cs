using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBook : MonoBehaviour
{
    public Transform bookLocations;
    public Transform[] bookLocationsArr;

    public bool trigger1; //for debug purposes- serve as triggers that replace player hands pointing at book
    public bool trigger2;
    public bool trigger3;

    Animator animator;
    int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bookLocationsArr = new Transform[bookLocations.transform.childCount];
        for (int i = 0; i < bookLocations.transform.childCount; i++)
        {
            bookLocationsArr[i] = bookLocations.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //change book location when player points at it 
        if(stage == 0 && trigger1) 
        {
            transform.position = bookLocationsArr[0].position; 
            stage++;
        }
        //player finds book again, change location 
        else if (stage == 1 && trigger2)
        {
            transform.position = bookLocationsArr[1].position;
            stage++;
        }
        //player finds it a third time
        else if(stage == 2 && trigger3)
        {
            //initiate book animation and advance story
            animator.enabled= true;
            stage++;
        }

    }
}
