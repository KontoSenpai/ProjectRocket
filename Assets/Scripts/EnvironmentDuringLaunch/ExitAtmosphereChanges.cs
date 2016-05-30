using UnityEngine;
using System.Collections;

public class ExitAtmosphereChanges : MonoBehaviour {

    public Light sun;

    public float intensityOnExit;

    void OnTriggerEnter()
    {
        sun.intensity = intensityOnExit;
    }
}
