using UnityEngine;
using System.Collections;

public class ExitAtmosphereChanges : MonoBehaviour {

    public Light sun;

    public float sunIntensityOnExit;
    public float rocketSpeedOnExit;

    public bool deactivateFog;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sun.intensity = sunIntensityOnExit;

            other.GetComponentInChildren<Movement>().flyStep = rocketSpeedOnExit;
            
            if (deactivateFog)
                RenderSettings.fog = false;
        }

    }
}
