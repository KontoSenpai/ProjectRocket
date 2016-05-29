using UnityEngine;
using System.Collections;

public class MiniGame3 : MonoBehaviour {

    public GameObject joystick;

    private bool miniGameOver;
    private bool minigameInstantiate;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
    public bool GetInitialized()
    {
        return minigameInstantiate;
    }

    public void Instantiate()
    {
        GetComponentInChildren<JoystickPlaneOrientation>().setStarted();
        minigameInstantiate = true;
    }
}
