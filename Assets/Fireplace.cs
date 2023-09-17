using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public bool lightFire = false;
    public GameObject Fire;


    // Update is called once per frame
    void Update()
    {
        if (!lightFire)
        {
            Fire.SetActive(false);

        }
        else
        {
            Fire.SetActive(true);

        }
    }
    public void ToggleFire()
    {
        Fire.SetActive(lightFire);
    }
}
