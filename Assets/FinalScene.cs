using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{

    public GameObject bookObj;
    private BookBehavior BookBehaviorObj;
    private FMOD.Studio.EventInstance fmod_instance;
    // Start is called before the first frame update
    void Start()
    {
        BookBehaviorObj = bookObj.GetComponent<BookBehavior>();
        BookBehaviorObj.closeBook();
        fmod_instance = FMODUnity.RuntimeManager.CreateInstance("event:/final_speech"); // play after story speech
        fmod_instance.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
