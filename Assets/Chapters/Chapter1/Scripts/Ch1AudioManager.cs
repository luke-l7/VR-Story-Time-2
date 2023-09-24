using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch1AudioManager : MonoBehaviour
{
    public static Ch1AudioManager Instance { get; private set; }
    private FMOD.Studio.EventInstance ambienceInstance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);    
        }


    }

    private void Start()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/scene1 background");
        ambienceInstance.start();
    }
     
    public void PlayOneTimeSound(string path)
    {
        RuntimeManager.PlayOneShot(path);
    }
    private void OnDestroy()
    {
        ambienceInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
