using UnityEngine;
using System.Collections;

public class SelectMinigame : MonoBehaviour {

    public ParticleSystem particule;
    public float facteur;

    void Update()
    {
        setParticule();
    }

    private void setParticule()
    {
        Vector3 fwd = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Vector3 point = hit.point - fwd / facteur;
            particule.transform.position = point;
        }
    }
}
