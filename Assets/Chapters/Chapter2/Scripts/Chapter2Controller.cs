using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chapter2Controller : MonoBehaviour
{
    public GameObject melody;
    public GameObject parrot;
    public GameObject turtle;

    private FMOD.Studio.EventInstance audioInstance;
    int stage = 0;
    enum GameState
    {
        WalkingToTurutle,
        TurtleConvo
    }
    GameState currState = GameState.WalkingToTurutle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(currState == GameState.WalkingToTurutle && Vector3.Distance(melody.transform.position, turtle.transform.position) < 7f)
        {
            currState= GameState.TurtleConvo;
            stage++;
        }
        else if (stage == 1 && currState == GameState.TurtleConvo ) 
        {
            melody.GetComponent<MelodyScene2>().stopWalking();
            audioInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Chapter2_1");
            audioInstance.start();
            stage++;
        }
        else if(stage == 2)
        {
            Vector3 direction = turtle.transform.position - melody.transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                melody.transform.rotation = Quaternion.LookRotation(direction);
                parrot.transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
