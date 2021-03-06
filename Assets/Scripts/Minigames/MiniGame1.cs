﻿using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour {

    public Light[] lights;
    public GameObject mouvement;

    private int step;
    private bool miniGameOver = false;

	// Use this for initialization
	void Start ()
    {
        step = 1;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if( step == 4 && miniGameOver == false)
        {
            mouvement.GetComponent<Movement>().setFlying();
            GetComponentInParent<MinigameSelection>().nextStep();
            miniGameOver = true;
        }
	    else if( step == 1 && GetComponentInChildren<PullLever>().getStep() == 2)
            step = 2;
        else if( step == 2 && GetComponentInChildren<CircleLever>().getStep() == 1)
        {
            step = 3;
            for( int i = 0; i < lights.Length-1; i++)
            {
                lights[i].enabled = true;
            }
        }
        else if( step == 3 && GetComponentInChildren<PullLever>().getStep() == 3)
        {
            step = 4;
            lights[3].enabled = true;
        }
   	}

    public int getMiniGameStep()
    {
        return step;
    }
}
