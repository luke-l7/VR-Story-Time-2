using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch1AudioManager : MonoBehaviour
{
    public static Ch1AudioManager Instance { get; private set; }

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



    public void PlayOneTimeSound(string path)
    {
        RuntimeManager.PlayOneShot(path);
    }
}
