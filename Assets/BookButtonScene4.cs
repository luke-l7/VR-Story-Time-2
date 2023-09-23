using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButtonScene4 : MonoBehaviour
{
    public ForestBook book;
    public Transform player;
    public float weight;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(book.transform.position + new Vector3(0, 9, 0), player.position, weight); ;
        transform.LookAt(player.position);

    }

    public void TriggerBookTranslation()
    {
        book.TriggerBookTranslation();
    }
}
