using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home_button_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }

    public void reutrnHome()
    {
        Debug.Log("ok");
        SceneManager.LoadScene(0);

    }
}