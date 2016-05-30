using UnityEngine;
using System.Collections;

public class CircleLever : MonoBehaviour {

    public ParticleSystem pointeur;
    public GameObject associatedLight;
    public bool antiHoraire;
    public Material[] materials;

    public float resistance;

    private GameObject circleLever;

    private Vector3 originalPosition;
    private Quaternion originalTransform;

    private float currentAngle = 0;
    private float finalAngle = -170;

    private float X = 0;
    private float Z = 0;

    private bool step = false;
    

	// Use this for initialization
	void Start ()
    {
        originalPosition = gameObject.GetComponent<CapsuleCollider>().center;
        //originalPosition.z = 0;
        originalTransform = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if( GetComponentInParent<MiniGame1>().getMiniGameStep() == 2)
        {
            if (Input.GetMouseButtonUp(0))
            {
                circleLever = null;
            }

            if (circleLever != null)
            {

                Vector3 source = originalPosition - transform.position;

                if ( Input.GetAxis("Mouse Y") > 0)
                    Z += resistance;
                else if( Input.GetAxis("Mouse Y") < 0)
                    Z -= resistance;   
                if (Input.GetAxis("Mouse X") > 0)
                        X += resistance;
                else if (Input.GetAxis("Mouse X") < 0)
                        X -= resistance;

                Vector3 aimed = new Vector3( 0, Z + originalPosition.y, X + originalPosition.z) - transform.position;

                source.x = 0;

                if( antiHoraire == true)
                    currentAngle = Vector3.Angle(aimed, source) * -1;
                else
                    currentAngle = Vector3.Angle(aimed, source);

                transform.rotation = originalTransform;
                transform.Rotate(new Vector3(0, 1, 0), currentAngle, Space.Self);

                if ( currentAngle <= finalAngle + 10)
                {
                    changeLightMaterial();
                    step = true;
                }
            }
        } 
	}

    public void setLever(GameObject inLever)
    {
        circleLever = inLever;
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

    public int getStep()
    {
        if (step == true)
            return 1;
        else
            return 0; 
    }
}
