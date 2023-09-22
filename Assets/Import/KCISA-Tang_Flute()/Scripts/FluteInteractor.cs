using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluteInteractor : MonoBehaviour
{

    public GameObject DoCube;
    public GameObject ReCube;
    public GameObject MiCube;
    public GameObject FaCube;
    public GameObject SoCube;
    public GameObject LaCube;
    public int SongNumber;
    
    

    string[] song1 = { "do", "do", "so", "so", "la", "la", "so" , "fa", "fa", "mi", "mi", "re", "re", "do" };
    string[] song2 = { "mi", "mi", "fa", "so", "so", "fa", "mi", "re", "do", "do", "re", "mi", "mi", "re", "re" };
    string[] song3 = {"re", "re", "mi", "do", "re", "mi", "fa", "re", "do", "re", "mi", "fa", "mi", "re", "do", "re" ,"mi", "mi", "fa", "so", "so", "fa", "mi", "re", "do", "do", "re", "mi", "mi", "re", "re" };
    int curr_note;
    

    // playover tools
    public bool playOver = false; // if finished interaction, this bool will activate to indicate that we should replay it to the player.
    public bool playOverAudio = false;
    private FMOD.Studio.EventInstance playover_instance;

    // Start is called before the first frame update
    void Start()
    {
        curr_note = 0; // this is the index of the current note that needs to be played etc [do,re,mi...]
                       // it is updated by the Note's Cube Poke Interactor directly, when the note button is pressed
                       // the XR Simple Interactor Script attached will call the 'advance' method and increase the note index.

        // activate the first note -
        string[] song = returnChosenSong(SongNumber);
        returnCubeNote(song[0]).SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        playover_instance.getPlaybackState(out state);
        string[] song = returnChosenSong(SongNumber);
        if (playOver && state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            string event_string;
            if(playOverAudio)
            {
                switch(SongNumber)
                {
                    case 1: event_string = "event:/goodjob_playback_audio"; break;
                    case 2: event_string = "event:/goodjob_playback_audio2"; break;
                    default: event_string = "event:/goodjob_playback_audio3"; break;
                }
                playover_instance = FMODUnity.RuntimeManager.CreateInstance(event_string);
                playover_instance.start();
                playOverAudio = false;
                return;
            }
            event_string = "event:/" + char.ToUpper(song[curr_note][0]) + song[curr_note][1];
            playover_instance = FMODUnity.RuntimeManager.CreateInstance(event_string);
            playover_instance.start();
            curr_note++;
        }
        if(curr_note == song.Length)
        {
            // FLUTE INTERACTION ENDS HERE - ADD CODE IF NECCESSARY
            Chapter1Controller.Instance.DonePlayingFlute = true;
            playOver = false;
        }
    }

    // returns the cube that corresponds to the note
    GameObject returnCubeNote(string note)
    {
        switch (note)
        {
            case "do":
                return DoCube;
            case "re":
                return ReCube;
            case "mi":
                return MiCube;
            case "fa":
                return FaCube;
            case "so":
                return SoCube;
            default:
                return LaCube;
        }
    }

    // returns the note array that is required
    string[] returnChosenSong(int idx)
    {
        switch (idx)
        {
            case 1:
                return song1;
            case 2:
                return song2;
            default:
                return song3;
        }
    }

    public void advance()
    {
        Debug.Log("advanced");
        string[] song = returnChosenSong(SongNumber);
        returnCubeNote(song[curr_note]).SetActive(false);
        curr_note++;
        if (curr_note < song.Length)
        {
            returnCubeNote(song[curr_note]).SetActive(true);
        }
        else
        {
            curr_note = 0;
            playOver = true; // if its false, it'll turn true, if true and turned false means we finished playover and flute interaction is done.
            playOverAudio = true;

        }
        // returnCubeNote(song[curr_note]).SetActive(true);
    }
}

