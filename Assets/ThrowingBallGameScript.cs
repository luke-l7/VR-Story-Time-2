using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBallGameScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw()
    {
        float desiredBallSpeed = 20.0f;
        float desiredBallLaunchAngle = 45.0f;

        Quaternion rotation = Quaternion.Euler(0, 0, desiredBallLaunchAngle);

        Vector3 velocity = rotation * (Vector3.right * desiredBallSpeed);

        GetComponent<Rigidbody>().velocity = velocity;

    }
}
