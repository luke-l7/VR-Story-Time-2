using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4Controller : MonoBehaviour
{
    private FMOD.Studio.EventInstance ambienceInstance;

    // Start is called before the first frame update
    void Start()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/night without hooting");
        ambienceInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
