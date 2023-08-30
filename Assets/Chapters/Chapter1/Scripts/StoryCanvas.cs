using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryCanvas : MonoBehaviour
{
    public static StoryCanvas Instance { get; private set; }
    int nextLine = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public TMP_Text StoryText;
    List<string> lines= new List<string>();
    private string ch1_1 = "In Harmonyville, music filled the air and brought joy to everyone's hearts. Melody, with her gift for playing the flute, embarked on a musical journey to inspire others";
    private string ch1_2 = "Suddenly, she stumbled upon a lost parrot named Echo, whose mimicry caused quite a commotion.";
    private string ch1_3 = "Echo squawked loudly, imitating the village's sounds, as Melody approached him";
    private string ch1_4 = "\"Hello, little parrot. Can you guide me through the forest?\"";
    private string ch1_5 = "Echo hopped from branch \r\nto branch, mimicking Melody's flute tune. Melody realized Echo's special trait could be a blessing in disguise.\r\n";


    // Start is called before the first frame update
    void Start()
    {
        lines.Add(ch1_1);
        lines.Add(ch1_2);
        lines.Add(ch1_3);
        lines.Add(ch1_4);
        lines.Add(ch1_5);
    }


    public void ChangeText()
    {
        if (nextLine < lines.Count)
        {
            StoryText.text = lines[nextLine++];
        }
    }
}
