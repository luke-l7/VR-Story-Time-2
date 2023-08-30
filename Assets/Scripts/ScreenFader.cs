using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance { get; private set; }

    public float fadeTime = 2f;
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
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            rend.material.SetColor("_Color", new Color(0f, 0f, 0f, t));
            //img.color = new Color(0f, 0f, 0f, t);
            yield return 0; //wait a frame and continue

        }
    }
    IEnumerator FadeOut(int sceneId)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            rend.material.SetColor("_Color", new Color(0f, 0f, 0f, t));

            //img.color = new Color(0f, 0f, 0f, t);
            yield return 0; //wait a frame and continue

        }
        SceneManager.LoadScene(sceneId);
    }
}
