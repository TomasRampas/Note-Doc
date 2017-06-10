using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	public SplineTextureMove[] backgroundLayers;
    public ObjectMovementSpeed[] backgroundObjects;
    public ObjectMovementSpeed[] backgroundObjectsReset;

    private void Start()
	{
		UpdateBackgroundState(0);
	}

	public void UpdateBackgroundState(int state)
	{
		switch(state)
		{
			//Start (Moves forwards)
			case 1:
				foreach (SplineTextureMove backgroundLayer in backgroundLayers)
					backgroundLayer.StartMovement();
                foreach (ObjectMovementSpeed backgroundObject in backgroundObjects)
                    backgroundObject.StartMovement();
				break;

			//GameOver (Moves backwards then stops)
			case 2:
				StartCoroutine("OnGameOver");
				break;

			//MainMenu (Stops)
			default:
				foreach (SplineTextureMove backgroundLayer in backgroundLayers)
					backgroundLayer.SettingsHelper(2);
                foreach (ObjectMovementSpeed backgroundObject in backgroundObjects)
                    backgroundObject.SettingsHelper(2);
                break;
		}
	}

	IEnumerator OnGameOver()
	{
		//NOTE: Starts moving background layers backwards
		foreach (SplineTextureMove backgroundLayer in backgroundLayers)
			backgroundLayer.SettingsHelper(1);
        foreach (ObjectMovementSpeed backgroundObject in backgroundObjectsReset)
            backgroundObject.SettingsHelper(3);

        //NOTE: Stop
        yield return new WaitForSeconds(0.5f);
		UpdateBackgroundState(0);
        yield return new WaitForSeconds(2f);
        // NOTE: Reset object possition to start
        foreach (ObjectMovementSpeed backgroundObject in backgroundObjects)
            backgroundObject.SettingsHelper(3);
    }
}
