using echo17.EndlessBook;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ForestBook : MonoBehaviour
{
    public Transform bookLocations;
    public Transform[] bookLocationsArr;
    public FluteInteractor flute;
    public Animals Animals;
    public bool trigger1; //for debug purposes- serve as triggers that replace player hands pointing at book
    public bool trigger2;
    public bool trigger3;
    public GameObject forestLights;
    bool coroutineRunning = false;
    private FMOD.Studio.EventInstance narratorInstance;
    private GameObject bookLight;

    Animator animator;
    int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bookLocationsArr = new Transform[bookLocations.transform.childCount];
        for (int i = 0; i < bookLocations.transform.childCount; i++)
        {
            bookLocationsArr[i] = bookLocations.transform.GetChild(i);
        }
        bookLight = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //change book location when player points at it 
        if (stage == 0 && trigger1)
        {
            transform.position = bookLocationsArr[0].position;
            RuntimeManager.PlayOneShot("event:/Chapter4_2");
            stage++;
        }
        //player finds book again, change location 
        else if (stage == 1 && trigger2)
        {
            transform.position = bookLocationsArr[1].position;
            RuntimeManager.PlayOneShot("event:/Chapter4_2");
            stage++;
        }
        //player finds it a third time
        else if (stage == 2 && trigger3)
        {
            //initiate book animation and advance story
            animator.enabled = true;
            MelodyScene4.Instance.LookAtBook();
            narratorInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter4_3");
            narratorInstance.start();
            StartCoroutine(waitSecondsAndOpen(14));
            coroutineRunning= true;
            stage++;
        }
        else if(stage == 3 && !coroutineRunning)
        {
            //animation stopped, open book and play sound
            //Lumiere flew to melody and opened its pages, revealing a musical score that could bring joy to the world. "Play this Melody, and watch the surprising transformation," Lumiere whispered as it opened.
            GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 1f);

            StartCoroutine(waitSecondsAndLetAnimalsOut(6));

            flute.gameObject.SetActive(true);
            stage++;
        }
        else if(stage==4 && flute.donePlayingFlute == true)
        {
            bookLight.GetComponent<Animator>().SetBool("Glow", true);
            forestLights.SetActive(true);
            narratorInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter4_4");
            narratorInstance.start();
            stage++;
        }
        if(stage == 5)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            narratorInstance.getPlaybackState(out state);
            if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                //transition back to kid room
                Debug.Log("fading back to bedroom");
                SceneLoadClass.SceneBackFrom = 4;
                ScreenFader.Instance.FadeTo(0);
            }
        }
    }
    public void TriggerBookTranslation()
    {
        switch(stage)
        {
            case 0:
                trigger1 = true;
                break;
            case 1: 
                trigger2 = true;
                break;
            case 2:
                trigger3 = true;
                break;
        }
    }

    IEnumerator waitSecondsAndOpen(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        coroutineRunning = false;
    }
    IEnumerator waitSecondsAndLetAnimalsOut(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Animals.LetAnimalsOut();
    }
}
