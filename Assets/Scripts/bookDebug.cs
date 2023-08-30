using echo17.EndlessBook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookDebug : MonoBehaviour
{
    private int currPage;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 0f);

        currPage = 1;    
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        turnPage();
    //    }
    //}
    //public void turnPage()
    //{
    //    this.GetComponent<EndlessBook>().TurnToPage(currPage, EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime, 3f);
    //    currPage += 2;

    //}
}
