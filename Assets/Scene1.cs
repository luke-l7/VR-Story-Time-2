using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public int StartPage;
    public int EndPage;
    public GameObject bookObj;
    private BookBehavior BookBehaviorObj;
    private Animator bookAnim;


    // narrator voice events
    string[] events_sequence;
    void Start()
    {
        bookAnim = bookObj.GetComponent<Animator>();
        BookBehaviorObj = bookObj.GetComponent<BookBehavior>();
        BookBehaviorObj.playPages(StartPage,EndPage);
    }

    // Update is called once per frame
    void Update()
    {
        // check whether RequestedPlay in BookBehavior is false, if yes then move scene
        if(!BookBehaviorObj.RequestedPlay) // means scene is finished playing
        {
            bookAnim.SetBool("enterScene", true);
            ScreenFader.Instance.FadeTo(3);
        }
    }
}
