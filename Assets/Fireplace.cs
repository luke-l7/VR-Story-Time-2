using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public bool lightFire = false;
    //public GameObject Fire;
    public ParticleSystem fire;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!lightFire)
        {
            fire.GetComponent<ParticleSystem>().Stop();
            //fire.Stop();
        }
        else
        {
            fire.GetComponent<ParticleSystem>().Play();

            //fire.Play();
        }
    }
    public void ToggleFire()
    {
        lightFire = !lightFire;
        if (lightFire)
        {
            fire.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            fire.GetComponent<ParticleSystem>().Stop();

        }
    }

}
