﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicScript : objectScript {

    public SpriteRenderer openChestSprite;
    public SpriteRenderer closedChestSprite;


    public SpriteRenderer[] textArray;

    float timer = 0;
    int textIndex = -1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isActiveObject)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //hurry it up you stupid mimic
            {
                if (timer > .1f)
                {
                    timer = .1f;
                }
            }

            if (timer <= 0)
            {
                if (textIndex + 2 <= textArray.Length)
                {
                    textIndex++;
                    textArray[textIndex].enabled = true;

                    timer = 2.0f;
                }
                else
                {
                    FinishInteracting(true);
                }
            }

            else if (timer <= .25f) //pause between lines of text
            {
                textArray[textIndex].enabled = false;
            }

            else
            {

            }

            timer -= Time.deltaTime; //the clock is ticking
        }
	}

    public override void Interact()
    {
        closedChestSprite.enabled = false;
        openChestSprite.enabled = true;
        overlayText.enabled = false;

        isActiveObject = true;
    }

    public override void FinishInteracting(bool dialogComplete)
    {
        isActiveObject = false;
        textArray[textIndex].enabled = false;
        timer = 0;

        if (dialogComplete || isFinished) //if you're done, you're not going back
        {
            //this is where a mimic would give you an item or powerup
            textIndex = textArray.Length - 2;
            isFinished = true;
        }
        else
        {
            //you left mid conversation you jerk, no item for you

            closedChestSprite.enabled = true;
            openChestSprite.enabled = false;
            textIndex = 0;
        }
    }

    public override void Overlay()
    {
        overlayText.enabled = true;
    }
}
