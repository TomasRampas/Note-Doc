using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class BlastTextureMove : MonoBehaviour {

    public PathGenerator pathGenerator;
    public Vector2 start;
    public Vector2 startRed;
    public Material redBeam;

    public GameObject beamLight;
    Light light;
    float lightIncrease = 4f;

    private bool runSpark = false;

	void Start ()
    {
        light = beamLight.GetComponent<Light>();
	}

    public void StartCoroutine()
    {
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        yield return new WaitForSeconds(0.5f);
        light.enabled = true;
        yield return new WaitForSeconds(0.16f); 
        while (light.intensity < 2)
        {
            float lightSpeed = lightIncrease * Time.deltaTime;
            light.intensity += lightSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(0.01f);
        while (light.intensity > 0.1)
        {
            float lightSpeed = lightIncrease * Time.deltaTime;
            light.intensity -= lightSpeed;
            yield return null;
        }
        light.intensity = 0f;
        light.enabled = false;
    }

}
