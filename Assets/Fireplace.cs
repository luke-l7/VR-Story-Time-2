using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public bool LightFire;
    public GameObject Fire;


    // Update is called once per frame
    void Update()
    {
        if (!LightFire)
        {
            Fire.SetActive(false);

        }
        else
        {
            Fire.SetActive(true);

        }
    }
}
