using UnityEngine;
using System.Collections;

public class JoystickPlaneOrientation : MonoBehaviour {

    public GameObject pivot;
    public GameObject[] planes;
    public GameObject[] associatedLights;
    public GameObject fusay;
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
    private Quaternion toastRotation;
    private Quaternion baseFusayRotation;

    // Use this for initialization
    void Start ()
    {
        baseRotation = pivot.transform.rotation;
        baseFusayRotation = fusay.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            pivot.transform.rotation = baseRotation;
            pivotRotX = 0;
            pivotRotY = 0;
            joyStick = null;
            if( xOk && yOk)
            {
                GetComponentInParent<MinigameSelection>().nextStep();
                fusay.transform.rotation = baseFusayRotation;
            }
        }

        if( joyStick != null)
        {
            RotateRocket();
            RotateJoystick();
        }

        if ( GetComponentInParent<MiniGame3>().GetInitialized())
        {
            TriggerLight();

            fusay.transform.rotation = baseFusayRotation;
            fusay.transform.Rotate(new Vector3(yRot, 0, xRot), Space.Self);
            toastRotation = fusay.transform.rotation;

            pivot.transform.rotation = toastRotation;
            pivot.transform.Rotate(new Vector3(pivotRotY, 0, pivotRotX));
        }
    }

    public void setStarted()
    {
        float randomRot = Random.Range(10, 30);

        if (Random.value > 0.5)
        {
            planes[0].transform.Rotate(new Vector3(0, randomRot, 0));
            fusay.transform.Rotate(new Vector3(randomRot, 0, 0), Space.Self);
            xRot += randomRot;
        }
        else
        {
            planes[0].transform.Rotate(new Vector3(0, -randomRot, 0));
            fusay.transform.Rotate(new Vector3(-randomRot, 0, 0), Space.Self);
            xRot -= randomRot;
        }

        randomRot = Random.Range(10, 30);

        if (Random.value > 0.5)
        {
            planes[1].transform.Rotate(new Vector3(0, randomRot, 0));
            fusay.transform.Rotate(new Vector3(0, 0, randomRot), Space.Self);
            yRot = +randomRot;
        }
        else
        {
            planes[1].transform.Rotate(new Vector3(0, -randomRot, 0));
            fusay.transform.Rotate(new Vector3(0, 0, -randomRot), Space.Self);
            yRot = -randomRot;
        }

    }
    
    private void RotateJoystick()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            if (pivotRotX > -25)
            {
                pivotRotX -= 1f;
            }
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            if (pivotRotX < 25)
            {
                pivotRotX += 1f;
            }
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            if (pivotRotY < 15)
            {
                pivotRotY += 1f;
            }

        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            if (pivotRotY > -10)
            {
                pivotRotY -= 1f;
            }

        }
    }

    private void RotateRocket()
    {
        if (pivotRotX > 0 && xRot < 50)
        {
            planes[0].transform.Rotate(new Vector3(0, -resistance, 0));
            xRot -= resistance;
        }
        else if (pivotRotX < 0 && xRot > -50)
        {
            planes[0].transform.Rotate(new Vector3(0, resistance, 0));
            xRot += resistance;
        }
        if (pivotRotY > 0 && yRot < 50)
        {
            planes[1].transform.Rotate(new Vector3(0, resistance, 0));
            yRot += resistance;
        }
        else if (pivotRotY < 0 && yRot > -50)
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
            xOk = true;
        }
        else
        {
            changeLightMaterial(associatedLights[0], false);
            xOk = false;
        }
        if( yRot >= -5 && yRot <= 5)
        {
            changeLightMaterial(associatedLights[1], true);
            yOk = true;
        }
        else
        {
            changeLightMaterial(associatedLights[1], false);
            yOk = false;
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
