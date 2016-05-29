using UnityEngine;
using System.Collections;

public class FlyScript : MonoBehaviour {

    public Material SkyboxMaterial;
    public float flyStep;
    public float BlackSkyY;
    public float updateFrequency;

    private float startPositionY;

    private float baseFlyStep;
    private float acceleratedFlyStep;

    private float startTime = -1.0f;

	// Use this for initialization
	void Start ()
    {
        startPositionY = transform.position.y;

        acceleratedFlyStep = flyStep * 100;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    baseFlyStep = flyStep;
        //    flyStep = acceleratedFlyStep;
        //}
        //else
        //{
        //    flyStep = baseFlyStep;
        //}


        Debug.Log(flyStep);

        if (startTime != -1.0f)
        {
            if (Time.realtimeSinceStartup - startTime > updateFrequency)
            {
                if (SkyboxMaterial)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + flyStep, transform.localPosition.z);
                    //float atmosphereThickness = RenderSettings.skybox.GetFloat("_AtmosphereThickness");
                    //float newAtmosphereThickness = atmosphereThickness - flyStep * 0.01f;
                    //if (newAtmosphereThickness > 0)
                    //    RenderSettings.skybox.SetFloat("_AtmosphereThickness", newAtmosphereThickness);
                    //else
                    //    RenderSettings.skybox.SetFloat("_AtmosphereThickness", 0);
                }

                startTime = Time.realtimeSinceStartup;
            }
        }
        else
        {
            startTime = Time.realtimeSinceStartup;
        }
	}
}
