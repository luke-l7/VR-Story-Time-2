using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class SoundBox : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.EventReference reference;

    FMOD.Studio.EventInstance playerState;
    void Start()
    {
        playerState = FMODUnity.RuntimeManager.CreateInstance(reference.Guid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {
        GetComponent<XRSimpleInteractable>().enabled = true;
    }

    public void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(reference.Guid);
        // GetComponent<XRSimpleInteractable>().enabled = false;
        // Invoke("Reset", 2);
    }
}
