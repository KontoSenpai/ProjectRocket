using UnityEngine;
using System.Collections;

public class MiniGame2 : MonoBehaviour {

    public GameObject[] levers;
    private int currentStep = 0;
    private bool miniGameOver = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentStep == 2 && miniGameOver == false)
        {
            GetComponentInParent<MinigameSelection>().nextStep();
            miniGameOver = true;
        }
        else
        {
	        if (levers[0].GetComponent<LeverTranslate>().getStep())
                currentStep = 1;
            if (levers[1].GetComponent<LeverTranslate>().getStep())
                currentStep = 2;
        }
	}

    public GameObject getLever()
    {
        return levers[currentStep];
    }
}
