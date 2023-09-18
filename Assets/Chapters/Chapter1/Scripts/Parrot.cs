    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parrot : MonoBehaviour
{
    public static Parrot Instance { get; private set; }

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
    private FMOD.Studio.EventInstance parrotSound;

     Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        parrotSound = FMODUnity.RuntimeManager.CreateInstance("event:/parrot3");
        parrotSound.start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void stopMakingCommotion()
    {
        Debug.Log("pausing");

        animator.SetBool("makeCommotion", false);
        //parrotSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        parrotSound.setPaused(true);
    }
    public void HopHouseToHouse()
    {
        Debug.Log("hopping");
        parrotSound.setPaused(false);

        animator.SetBool("shouldHop", true);
    }
    public void GoToFlute()
    {
        Debug.Log("GoToFlute");
        parrotSound.setPaused(false);

        animator.SetBool("ShouldGoToFlute", true);
    }

}
