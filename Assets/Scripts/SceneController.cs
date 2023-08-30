//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SceneController : MonoBehaviour
//{
//    public static SceneController Instance;
//    private void Awake()
//    {
//        if(Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject); //keep the instance when transitioning to a new scene
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//    public void TransitionToScene(int sceneId)
//    {
//        SceneManager.LoadScene(sceneId);
//    }
//}
