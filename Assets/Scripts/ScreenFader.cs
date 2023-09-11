using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance { get; private set; }

<<<<<<< HEAD
    public float fadeTime = 0.5f;
=======
    public float fadeTime = 1000000f;
>>>>>>> 4899888956fa06c455ae4d23fd039bf8fec27b81
    public Color fadeColor;
    private Renderer rend;
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
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void FadeTo(int sceneId)
    {
        StartCoroutine(FadeOut(sceneId));
    }
    IEnumerator FadeIn()
    {
        float t = fadeTime;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            rend.material.SetColor("_Color", new Color(0f, 0f, 0f, t / 2));
            //img.color = new Color(0f, 0f, 0f, t);
            yield return 0; //wait a frame and continue

        }
    }
    IEnumerator FadeOut(int sceneId)
    {
        float t = 0f;
        while (t < fadeTime)
        {
<<<<<<< HEAD
            t += Time.deltaTime * fadeTime;
            rend.material.SetColor("_Color", new Color(0f, 0f, 0f, t));
=======
            t += Time.deltaTime;
            rend.material.SetColor("_Color", new Color(0f, 0f, 0f, t / 2));
>>>>>>> 4899888956fa06c455ae4d23fd039bf8fec27b81

            //img.color = new Color(0f, 0f, 0f, t);
            yield return 0; //wait a frame and continue

        }
        SceneManager.LoadScene(sceneId);
    }
}
