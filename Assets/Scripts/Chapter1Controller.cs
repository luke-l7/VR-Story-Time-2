using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Chapter1Controller : MonoBehaviour
{
    //parrot melody convo
    public GameObject Parrot;
    public GameObject Melody;
    public GameObject Player;

    //pig donkey convo
    public Transform PigDonkey;
    public Transform pigCanvas;
    public Transform donkeyCanvas;
    string pig1 = "i want me some pineapples!";
    string donkey1 = "no pineapples here";
    enum GameState
    {
        melodyWaiting,
        melodyParrotConvo,
        convoEnd
    }
    GameState currState= GameState.melodyWaiting;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //if(AudioManager.Instance!= null)
        //    AudioManager.Instance.PlayFirstLevelMusic();




    }

    // Update is called once per frame
    void Update()
    {
        if (currState == GameState.melodyWaiting && Vector3.Distance(Parrot.transform.position, Player.transform.position) < 5f)
        {
            MelodyCh1.Instance.shouldWait = false;
        }
        if (currState == GameState.melodyWaiting && Vector3.Distance(PigDonkey.transform.position, Player.transform.position) < 5f)
        {
            initiaiteConversationPigDonkey();
        }
    }
    void initiaiteConversationPigDonkey()
    {

        pigCanvas.GetComponent<PopupSystem>().ShowPopUp(pig1);
        donkeyCanvas.GetComponent<PopupSystem>().ShowPopUp(donkey1);
    }


}
