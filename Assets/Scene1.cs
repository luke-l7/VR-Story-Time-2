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
        if(!BookBehaviorObj.RequestedPlay) // means s             cene is finished playing
        {
            bookAnim.SetBool("enterScene", true);
            AudioManager.Instance.StopMainMusic();
            ScreenFader.Instance.FadeTo(1);
        }
    }
}
