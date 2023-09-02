using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    [HideInInspector]
    public GameObject LampLight;

    [HideInInspector]
    public GameObject DomeOff;

    [HideInInspector]
    public GameObject DomeOn;

    public bool TurnOn;
    public bool isOn;
    

	// Use this for initialization
	void Start () {
        isOn = false;
    }
	
	// Update is called once per frame
	void Update () {
        


        if (TurnOn== true)
        {
            LampLight.SetActive(true);
            DomeOff.SetActive(false);
            DomeOn.SetActive(true);

        }
        if (TurnOn == false)
        {
            LampLight.SetActive(false);
            DomeOff.SetActive(true);
            DomeOn.SetActive(false);

        }
    }

    public void ChangeState()
    {
        Debug.Log("entered");
        if(TurnOn) // turn off
        {
            TurnOn = false;
            
        } 
        else // turn on
        {
            TurnOn = true;
        }
    }
}
