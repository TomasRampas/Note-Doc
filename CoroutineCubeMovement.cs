using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCubeMovement : MonoBehaviour {

    float speedCube = 2f;
    Vector3 direction = new Vector3(0, -1f, 0);

	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CubeMovement());
        }
	}

    IEnumerator CubeMovement()
    {
        while (transform.position.y > -10f)
        {
            Vector3 velocityCube = direction * speedCube;
            Vector3 moveAmountCube = velocityCube * Time.deltaTime;
            transform.position += moveAmountCube;
            yield return null;
        }
        transform.position = Vector3.zero;
    }
}
