using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookButton : MonoBehaviour
{
    public GameObject book;
    public Transform player;
    public float weight;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(book.transform.position, player.position, weight); ;
        transform.LookAt(player.position);

    }
    public void endLife()
    {
        Destroy(gameObject);
    }

}
