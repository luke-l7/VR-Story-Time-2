using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boy_button_script : MonoBehaviour
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
        Debug.Log("collided");
        SceneManager.LoadScene(1);
    }
    public void openRoom()
    {
        Debug.Log("collided");
        SceneManager.LoadScene(1);
    }


}
