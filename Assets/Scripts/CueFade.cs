using UnityEngine;
using System.Collections;

public class CueFade : MonoBehaviour {

    public bool fadeIn = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!fadeIn)
                other.GetComponentInChildren<FadeToWhite>().fadeToWhite();
            else
                other.GetComponentInChildren<FadeToWhite>().fadeToClear();

        }
    }
}
