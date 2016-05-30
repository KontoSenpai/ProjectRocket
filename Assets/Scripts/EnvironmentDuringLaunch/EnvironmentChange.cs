using UnityEngine;
using System.Collections;

public class EnvironmentChange : MonoBehaviour {

    public GameObject referential;

    public float initialAtmosphereThickness;
    public float distanceEndAtmosphere;

    public float initialFogDensity;
    public float fogStepDecrease;
    public float limitFogValue;

    public GameObject sun;
    public float initialSunIntensity;
    public float sunIntensityStepDecrease;
    public float limitSunIntensityValue;

    public float updateFrequency;

    private Vector3 startPosition;
    private float startTime = -1.0f;

    // Use this for initialization
    void Start () {
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", initialAtmosphereThickness);
        RenderSettings.fogDensity = initialFogDensity;

        startPosition = referential.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime != -1.0f)
        {
            if (Time.realtimeSinceStartup - startTime > updateFrequency)
            {
                // Modify atmosphere from blue to black
                float newAtmosphereThickness = ((distanceEndAtmosphere - Vector3.Distance(startPosition, referential.transform.position)) / distanceEndAtmosphere) * initialAtmosphereThickness;

                if (newAtmosphereThickness > 0)
                    RenderSettings.skybox.SetFloat("_AtmosphereThickness", newAtmosphereThickness);
                else
                    RenderSettings.skybox.SetFloat("_AtmosphereThickness", 0.0f);

                //Decrease fog Density
                float newFogDensity = RenderSettings.fogDensity - fogStepDecrease;

                if (newFogDensity > limitFogValue)
                    RenderSettings.fogDensity = newFogDensity;
                else
                    RenderSettings.fogDensity = 0.0f;

                //Decrease
            }
        }
        else
        {
            startTime = Time.realtimeSinceStartup;
        }
    }
}
