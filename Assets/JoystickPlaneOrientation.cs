using UnityEngine;
using System.Collections;

public class JoystickPlaneOrientation : MonoBehaviour {

    public GameObject pivot;
    public GameObject[] planes;
    public GameObject[] associatedLights;
    public Material[] materials;

    public float resistance;

    private GameObject joyStick;

    private bool xOk;
    private bool yOk;


    private float xRot = 0;
    private float yRot = 0;
    private float pivotRotX = 0;
    private float pivotRotY = 0;

    private Quaternion baseRotation;

    // Use this for initialization
    void Start ()
    {
        baseRotation = pivot.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            base.transform.rotation = baseRotation;
            pivotRotX = 0;
            pivotRotY = 0;
            joyStick = null;
        }

        if( joyStick != null)
        {
            RotateJoystick();
            RotateRocket();
        }
        if (GetComponentInParent<MiniGame3>().GetInitialized())
        {
            TriggerLight();
            pivot.transform.rotation = baseRotation;
            pivot.transform.Rotate(new Vector3(pivotRotY, 0, pivotRotX));
        }
    }

    public void setStarted()
    {
        float randomRot = Random.Range(10, 30);

        if (Random.value > 0.5)
        {
            planes[0].transform.Rotate(new Vector3(0, randomRot, 0));
            xRot += randomRot;
        }
        else
        {
            planes[0].transform.Rotate(new Vector3(0, -randomRot, 0));
            xRot -= randomRot;
        }

        if (Random.value > 0.5)
        {
            planes[1].transform.Rotate(new Vector3(0, randomRot, 0));
            yRot = +randomRot;
        }
        else
        {
            planes[1].transform.Rotate(new Vector3(0, -randomRot, 0));
            yRot = -randomRot;
        }

    }
    
    private void RotateJoystick()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            if (pivotRotX < 25)
            {
                pivotRotX += 1f;
            }
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            if (pivotRotX > -25)
            {
                pivotRotX -= 1f;
            }
        }

        if (Input.GetAxis("Mouse Y") > 0)
        {
            if (pivotRotY > -10)
            {
                pivotRotY -= 1f;
            }

        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            if (pivotRotY < 15)
            {
                pivotRotY += 1f;
            }
        }
    }

    private void RotateRocket()
    {
        if (pivotRotX > 0)
        {
            planes[0].transform.Rotate(new Vector3(0, resistance, 0));
            xRot += resistance;
        }
        else if (pivotRotX < 0)
        {
            planes[0].transform.Rotate(new Vector3(0, -resistance, 0));
            xRot -= resistance;
        }

        if (pivotRotY > 0)
        {
            planes[1].transform.Rotate(new Vector3(0, resistance, 0));
            yRot += resistance;
        }
        else if (pivotRotY < 0)
        {
            planes[1].transform.Rotate(new Vector3(0, -resistance, 0));
            yRot -= resistance;
        }
    }

    private void TriggerLight()
    {
        if( xRot >= -5 && xRot <= 5)
        {
            changeLightMaterial(associatedLights[0], true);
        }
        else
        {
            changeLightMaterial(associatedLights[0], false);
        }
        if( yRot >= -5 && yRot <= 5)
        {
            changeLightMaterial(associatedLights[1], true);
        }
        else
        {
            changeLightMaterial(associatedLights[1], false);
        }
    }

    private void changeLightMaterial(GameObject associatedLight, bool okey)
    {
        Renderer toast = associatedLight.GetComponent<Renderer>();
        Material[] mats = new Material[3];
        if( okey)
        {
            mats[0] = materials[1];
            mats[1] = toast.sharedMaterials[1];
            mats[2] = toast.sharedMaterials[2];
            toast.materials = mats;
        }
        else
        {
            mats[0] = materials[0];
            mats[1] = toast.sharedMaterials[1];
            mats[2] = toast.sharedMaterials[2];
            toast.materials = mats;
        }
    }


    public void setJoystick(GameObject hitObject)
    {

        joyStick = hitObject;
    }

    public bool getX()
    {
        return xOk;
    }

    public bool getY()
    {
        return yOk;
    }


}
