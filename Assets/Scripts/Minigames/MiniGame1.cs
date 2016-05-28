using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour {

    private int step;
    private bool miniGameOver = false;

	// Use this for initialization
	void Start ()
    {
        step = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if( step == 4 && miniGameOver == false)
        {
            GetComponentInParent<MinigameSelection>().nextStep();
            miniGameOver = true;
        }
	    else if( step == 1 && GetComponentInChildren<PullLever>().getStep() == 2)
            step = 2;
        else if( step == 2 && GetComponentInChildren<CircleLever>().getStep() == 1)
            step = 3;
        else if( step == 3 && GetComponentInChildren<PullLever>().getStep() == 3)
            step = 4;  
   	}

    public int getMiniGameStep()
    {
        return step;
    }
}
