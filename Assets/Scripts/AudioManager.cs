using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    FMOD.Studio.EventInstance music;
    FMOD.Studio.EventInstance currentInstance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); //keep the instance when transitioning to a new scene
        }
        else
        {
            Destroy(gameObject);
        }
        //sleeping room music
        music = RuntimeManager.CreateInstance("event:/roomMusic");
        music.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(this.transform));
        RuntimeManager.AttachInstanceToGameObject(music, transform);

        //first level music

    }
    // Start is called before the first frame update
    void Start()
    {
        currentInstance= music;

        //removed annoying music for debug and sanity purposes
        currentInstance.start();

    }

    public void ActivateBookSound()
    {
        music.setParameterByName("Parameter 3", 1);
    }
    public void PlayFirstLevelMusic()
    {
        currentInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

    }
    public void FirstChapter()
    {

    }
}
