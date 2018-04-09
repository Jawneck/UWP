using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    //Constants and Variable
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    private int XDirection = 1;
    private int Speed = 2;

    // Update is called once per frame. This method makes the enemy move.
    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            XDirection = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            XDirection = 1;
        }

        Vector3 Movement = Vector3.right * XDirection * Speed * Time.deltaTime;
        transform.Translate(Movement);
    }
    
}