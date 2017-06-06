using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class BlastTextureMove : MonoBehaviour {

    public PathGenerator pathGenerator;
    public float scrollSpeed;
    float offset2;
    public Vector2 offset;
    public Vector2 start;

	private bool runSpark = false;

	void Start () {
        pathGenerator = GetComponent<PathGenerator>();
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            runSpark = true;
        }

        if (runSpark == true)
        {
            offset2 = scrollSpeed;
            offset = new Vector2(0, offset2);
            pathGenerator.uvOffset += (start + offset) * Time.deltaTime;
        }
        Debug.Log("<color=red><b>offset</b></color>" + offset);

    }
}
