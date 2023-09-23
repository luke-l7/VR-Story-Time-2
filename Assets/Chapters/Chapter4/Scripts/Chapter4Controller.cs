using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4Controller : MonoBehaviour
{
    private FMOD.Studio.EventInstance ambienceInstance;
    private FMOD.Studio.EventInstance narratorInstance;

    

    // Start is called before the first frame update
    void Start()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/night without hooting");
        ambienceInstance.start();

        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter4_1");
        ambienceInstance.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
