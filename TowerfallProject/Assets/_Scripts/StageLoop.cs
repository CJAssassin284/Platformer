using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoop : MonoBehaviour {

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float buffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    public float distanceZ = 10.0f;

    void Awake()
    {
        // set Vector3 to ( camera left/right limits, spaceship Y, spaceship Z )
        // this will find a world-space point that is relative to the screen

        // using the camera's position from the origin (world-space Vector3(0,0,0)
       leftConstraint = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, 0 - Camera.main.transform.position.z) ).x;
        rightConstraint = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0.0f, 0 - Camera.main.transform.position.z) ).x;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f,Screen.height, 0 - Camera.main.transform.position.z)).y;
        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0 - Camera.main.transform.position.z)).y;


        // using a specific distance
        //leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        //rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
    }


    void Update()
    {

        if (transform.position.x < leftConstraint - buffer)
        {
            // ship is past world-space view / off screen
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z); // move ship to opposite side
        }

        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);  // move ship to opposite side

        }

        if (transform.position.y < bottomConstraint - buffer)
        {
            // ship is past world-space view / off screen
            transform.position = new Vector3(transform.position.x , topConstraint + buffer, transform.position.z); // move ship to opposite side
        }

        if (transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);  // move ship to opposite side

        }
    }
}


