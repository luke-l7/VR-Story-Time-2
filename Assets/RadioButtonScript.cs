using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioButtonScript : MonoBehaviour
{
    public FMODUnity.EventReference reference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSong()
    {
        Debug.Log("playing radio song");
        FMODUnity.RuntimeManager.PlayOneShot(reference.Guid);
    }
}
