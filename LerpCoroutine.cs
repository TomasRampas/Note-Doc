using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    // FUNCTION INFO --------------------
    // - Fluent transition between two values, use of Coroutines + Lerp
    // - Each time Q pressed, values move up a lvl
    // - Each time W pressed, transition goes to set lvl no matter how high the current lvl was
    // ----------------------------------


    float additionValue = 4f;
    float valueStart = 2f;
    float slowDownBonus = 6f;
    float valueEnd;
    float speedOfTransition = 0.5f;
    float coroutineCountdown;


    void Start ()
    {
        valueEnd = valueStart;
        coroutineCountdown = additionValue;
	}
	
	void Update ()
    {
        // NOTE: Next Speed Progression Lvl Reached
        if (Input.GetKeyDown(KeyCode.Q))
        {
            valueEnd = valueStart + additionValue;
            StartCoroutine (numberMovement(valueStart,valueEnd));
        }

        // NOTE: Slowdown Bonus Picked
        if (Input.GetKeyDown(KeyCode.W))
        {
            valueEnd = slowDownBonus;
            StartCoroutine(numberMovement(valueStart, valueEnd));
        }

    }

    IEnumerator numberMovement(float min, float max)
    {

        while (coroutineCountdown > 0)
        {
            coroutineCountdown -= speedOfTransition * Time.deltaTime;

            valueStart = Mathf.Lerp(valueStart, valueEnd, Time.deltaTime * speedOfTransition);
            Debug.Log("<color=cyan><b>IN COROUTINE: Value start" + valueStart + "</b></color>");
            yield return null;
        }

        coroutineCountdown = additionValue;
        Debug.Log("<color=red><b>Countdown reached</b></color>");
    }

}
