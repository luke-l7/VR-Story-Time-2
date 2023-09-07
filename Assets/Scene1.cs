using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{

    public GameObject Book;
    // Start is called before the first frame update
    void Start()
    {
        // open the book
        Book.GetComponent<BookBehavior>().openBook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
