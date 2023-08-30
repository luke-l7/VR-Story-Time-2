using echo17.EndlessBook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloomEffect : MonoBehaviour
{
    public GameObject book;
    public Material glowMat;
    public Material originalMat;
    PostProcessVolume pp;
    private Bloom bloom;
    public float startIntensity = 1f;
    float targetIntensity = 35f;
    private float time;
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        book.GetComponent<EndlessBook>().SetMaterial(0, originalMat);
        pp = null;
        //pp.profile.TryGetSettings(out bloom);
    }
    private void Update()
    {
        //TODO: this should be called when it is night 
        //activateBloomGlow();
        
    }
    public void activateBloomGlow()
    {
        if (pp == null)
        {
            pp = this.GetComponent<PostProcessVolume>();
            pp.profile.TryGetSettings(out bloom);
        }

        book.GetComponent<EndlessBook>().SetMaterial(0,glowMat);
        time += speed * Time.deltaTime;
        // calculate the desired intensity using a sine wave between the min and max intensities
        float intensity = Mathf.Lerp(startIntensity, targetIntensity, Mathf.Sin(time));
        Debug.Log(intensity);
        bloom.intensity.value = intensity;
        if(intensity == startIntensity)
        {
            book.GetComponent<EndlessBook>().SetMaterial(0, originalMat);

        }
        else
        {
            book.GetComponent<EndlessBook>().SetMaterial(0, glowMat);

        }
    }
    public void deactivateBloomEffect()
    {
        bloom.intensity.value = 1;
        book.GetComponent<EndlessBook>().SetMaterial(0, originalMat);

    }

}
