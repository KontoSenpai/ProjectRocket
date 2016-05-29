﻿using UnityEngine;
using System.Collections;

public class LeverTranslate : MonoBehaviour {

    public bool right;
    public float resistance;

    public GameObject associatedLight;
    public Material[] materials;

    private Vector3 originalPosition;
    private GameObject lever;
    private bool stepOver;

	// Use this for initialization
	void Start ()
    {
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {   
	    if( Input.GetMouseButtonUp(0))
        {
            lever = null;
        }

        if( lever != null && stepOver == false && lever == GetComponentInParent<MiniGame2>().getLever())
        {
            if( right == true && lever.transform.position.x >= originalPosition.x + 0.260)
            {
                changeLightMaterial();
                stepOver = true;
            }
            else if( right == false && lever.transform.position.x <= originalPosition.x - 0.260)
            {
                changeLightMaterial();
                stepOver = true;
            }

            if (right == true)
            {
                if ( Input.GetAxis("Mouse X") > 0)
                    lever.transform.position = new Vector3( lever.transform.position.x + resistance, lever.transform.position.y, lever.transform.position.z);
                else if( Input.GetAxis("Mouse X") < 0 && lever.transform.position.x > originalPosition.x)
                    lever.transform.position = new Vector3(lever.transform.position.x - resistance, lever.transform.position.y, lever.transform.position.z);
            }
            else
            {
                if( Input.GetAxis("Mouse X") < 0)
                    lever.transform.position = new Vector3(lever.transform.position.x - resistance, lever.transform.position.y, lever.transform.position.z);
                else if( Input.GetAxis("Mouse X") > 0 && lever.transform.position.x < originalPosition.x)
                    lever.transform.position = new Vector3(lever.transform.position.x + resistance, lever.transform.position.y, lever.transform.position.z);
            }
        }
	}

    public void setLever( GameObject hitObject)
    {
        lever = hitObject;
    }

    public void changeLightMaterial()
    {
        Renderer toast = associatedLight.GetComponent<Renderer>();
        Material[] mats = new Material[3];
        mats[0] = materials[1];
        mats[1] = toast.sharedMaterials[1];
        mats[2] = toast.sharedMaterials[2];
        toast.materials = mats;
    }

    public bool getStep()
    {
        return stepOver;
    }
}