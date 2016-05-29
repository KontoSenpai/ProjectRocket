using UnityEngine;
using System.Collections;

public class ChangeMesh : MonoBehaviour {

    public GameObject[] objectsToDisable;

    public GameObject[] objectsToEnable;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < objectsToDisable.Length; i++)
                objectsToDisable[i].SetActive(false);

            for (int i = 0; i < objectsToEnable.Length; i++)
                objectsToEnable[i].SetActive(true);
        }
    }
}
