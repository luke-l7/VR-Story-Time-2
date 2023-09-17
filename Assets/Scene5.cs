using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5 : MonoBehaviour
{
    public int StartPage;
    public int EndPage;
    public GameObject bookObj;
    public int InteractionSceneID;
    private BookBehavior BookBehaviorObj;
    private Animator bookAnim;

    // Start is called before the first frame update
    void Start()
    {
        bookAnim = bookObj.GetComponent<Animator>();
        BookBehaviorObj = bookObj.GetComponent<BookBehavior>();
        BookBehaviorObj.playPages(StartPage, EndPage);
    }

    // Update is called once per frame
    void Update()
    {
        // check whether RequestedPlay in BookBehavior is false, if yes then move scene
        if (!BookBehaviorObj.RequestedPlay) // means s             cene is finished playing
        {
            bookAnim.SetBool("enterScene", true);
            AudioManager.Instance.StopMainMusic();
            ScreenFader.Instance.FadeTo(InteractionSceneID);
        }
    }
}
