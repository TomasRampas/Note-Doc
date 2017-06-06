using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class BlastTextureMove : MonoBehaviour {

    public PathGenerator pathGenerator;
    public Vector2 start;

    // INFO: Coroutine parts
    Vector2 input = new Vector2(0, -1f);
    float speed = 3f;

    private bool runSpark = false;

	void Start () {
        pathGenerator = GetComponent<PathGenerator>();
	}

    void FixedUpdate()
    {
        #region TEST INPUT
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine();
        }
        #endregion
    }

    public void StartCoroutine()
    {
        StartCoroutine(BeamMovement());
    }

    #region BEAM COROUTINE

    IEnumerator BeamMovement()
    {
        while (pathGenerator.uvOffset.y > -1f)
        {
            Vector2 velocity = input * speed;
            Vector2 moveAmount = velocity * Time.deltaTime;
            pathGenerator.uvOffset += moveAmount;
            yield return null;
        }
        pathGenerator.uvOffset = start;
    }

    #endregion

}
