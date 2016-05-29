using UnityEngine;
using System.Collections;

public class PullLever : MonoBehaviour {

    public GameObject[] associatedLight;
    public Material[] materials;

    private GameObject lever;
    private bool keyUp;
    private bool keyDown;
    private float basePos = 0;
    private float pos = 0;
    private float finalPos = 0.2f;

    bool step1 = false;
    bool step2 = false;
	// Use this for initialization

	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if( Input.GetMouseButtonUp(0))
        {
            lever = null;
        }

        if( lever != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                keyUp = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                keyUp = false;
            }
            if ( Input.GetKeyDown( KeyCode.DownArrow))
            {
                keyDown = true;
            }
            if( Input.GetKeyUp( KeyCode.DownArrow))
            {
                keyDown = false;
            }

            if ( step1 == false)
            {
                if (keyDown == true && pos < finalPos)
                {
                    lever.transform.Translate(new Vector3(0, 0.01f, 0), Space.Self);
                    pos += 0.01f;
                }
                else if (pos >= finalPos)
                {
                    Renderer toast = associatedLight[0].GetComponent<Renderer>();
                    Material[] mats = new Material[3];
                    mats[0] = materials[1];
                    mats[1] = toast.sharedMaterials[1];
                    mats[2] = toast.sharedMaterials[2];
                    toast.materials = mats;
                    step1 = true;
                }
            }
            else if( (step1 == true && step2 == false) && GetComponentInParent<MiniGame1>().getMiniGameStep() == 3)
            {
                if (keyUp == true && pos >= basePos)
                {
                    lever.transform.Translate(new Vector3(0, -0.01f, 0), Space.Self);
                    pos -= 0.01f;
                }
                else if (pos <= basePos)
                {
                    Renderer toast = associatedLight[1].GetComponent<Renderer>();
                    Material[] mats = new Material[3];
                    mats[0] = materials[1];
                    mats[1] = toast.sharedMaterials[1];
                    mats[2] = toast.sharedMaterials[2];
                    toast.materials = mats;
                    step2 = true;
                }
            }

        }
	}

    public void setLever( GameObject inLever)
    {
        lever = inLever;
    }

    public int getStep()
    {
        int retVal = -1;
        if (step1 == false)
            retVal = 1;
        else if (step1 == true && step2 == false)
            retVal = 2;
        else if (step1 == true && step2 == true)
            retVal = 3;
        return retVal;
    }
}