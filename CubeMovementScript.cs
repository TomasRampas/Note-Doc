using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementScript : MonoBehaviour {

    /*
    EXPLANATION:
    - Movement of a cube up, down or not at all
    - Done through changing values of a Vector3 value
    */

    float speed = 10;
    float direction = 0;     

	void Update () {

        // INFO: Direction selection
        if (Input.GetKeyDown(KeyCode.Q))
        {
            direction = -0.1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            direction = 0f;
        }

        // INFO: Setting of the movement direction
        Vector3 input = new Vector3(0,direction,0);

        // INFO: Velocity allows me to set higher or lower speed of movement
        Vector3 velocity = input * speed;

        // INFO: Time.deltaTime sets the movement to be frame independent
        Vector3 moveAmount = velocity * Time.deltaTime;

        // INFO: Setting object in motion
        transform.position += moveAmount;
	}
}
