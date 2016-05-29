using UnityEngine;
using System.Collections;

public class MinigameSelection : MonoBehaviour {

    public Camera cam;
    public GameObject[] listMinigames;
    private GameObject currentGame;
    private int currentGameID = 0;

    // Initialisation de l'ordre des minijeux
    // Pour le débug on garde l'ordre normal
    void Start ()
    {
        currentGame = listMinigames[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 fwd = cam.transform.forward;
        RaycastHit hit;
        GameObject hitObject;
        GameObject parentObject;




        if (Physics.Raycast( cam.transform.position, fwd, out hit))
        {
            hitObject = hit.transform.gameObject;
            parentObject = hitObject.transform.parent.gameObject;
            //Si l'élément parent selectionné est le mini-jeu actif
            if( parentObject.tag == currentGame.tag)
            {
                if (currentGame.tag == "Game1")
                    handleFirstMinigame(hitObject);
                else if (currentGame.tag == "Game2")
                    handleSecondMinigame(hitObject);
                else if (currentGame.tag == "Game3")
                {
                    if (!currentGame.GetComponent<MiniGame3>().GetInitialized())
                        currentGame.GetComponent<MiniGame3>().Instantiate();
                    handleThirdMinigame(hitObject);
                }
            }
        }
    }

    public void nextStep()
    {
        currentGameID++;
        currentGame = listMinigames[currentGameID];
    }

    public void handleFirstMinigame(GameObject hit)
    {
        if( Input.GetMouseButtonDown(0))
        {
            if (hit.tag == "LeverPull")
                hit.GetComponent<PullLever>().setLever(hit);
            if (hit.tag == "LeverCircle")
                hit.GetComponent<CircleLever>().setLever(hit);
        }
    }

    public void handleSecondMinigame( GameObject hit)
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (hit.tag == "LeverTranslate")
            {
                hit.GetComponent<LeverTranslate>().setLever(hit);
            }   
        }
    }

    public void handleThirdMinigame( GameObject hit)
    {
        if( Input.GetMouseButtonDown(0))
        {
            if( hit.tag == "Joystick")
            {
                hit.GetComponent<JoystickPlaneOrientation>().setJoystick(hit);
            }
        }
    }
}
