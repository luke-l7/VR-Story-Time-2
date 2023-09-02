using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampButtonScript : MonoBehaviour
{
    public FMODUnity.EventReference reference;
    private Animation anim;
    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        isOn = !isOn;
        FMODUnity.RuntimeManager.PlayOneShot(reference.Guid);

        if(isOn) // its turned on - play on animation
        {
            anim.Play("ButtonFlipAnim");
        }
        else // its turned off
        {
            anim.Play("ButtonFlipBackAnim");
        }
    }
}
