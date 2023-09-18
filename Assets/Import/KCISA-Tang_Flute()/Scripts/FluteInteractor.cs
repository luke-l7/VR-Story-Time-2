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
    string[] song3 = {,"re", "re", "mi", "do", "re", "mi", "fa", "re", "do", "re", "mi", "fa", "mi", "re", "do", "re",
            ,"mi", "mi", "fa", "so", "so", "fa", "mi", "re", "do", "do", "re", "mi", "mi", "re", "re" };
    int curr_note;

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
            Chapter1Controller.Instance.DonePlayingFlute = true;
        }
        // returnCubeNote(song[curr_note]).SetActive(true);
    }
}

