using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicScript : objectScript {

    public SpriteRenderer openChestSprite;
    public SpriteRenderer closedChestSprite;
    public SpriteRenderer wineSprite;
    public enemyManagerManager enemyManagerManager;

    public SpriteRenderer[] textArray; //make sure there's empty space afterwards
    public SpriteRenderer[][] responseArray;

    float timer = 0;
    public int textIndex = -1;
    public int exitIndex; //the last line of dialogue if you didn't fuck up


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isActiveObject)
        {
            if (Input.GetButtonDown("Interact")) //hurry it up you stupid mimic
            {
                if (timer > .1f)
                {
                    timer = .1f;
                }
            }


            if (timer <= 0)
            {
                if (textArray[textIndex + 1] != null)
                {
                    textIndex++;
                    textArray[textIndex].enabled = true;
                    if (textIndex == 2)
                    {
                        wineSprite.enabled = true;
                    }

                    timer = 2.0f;
                }
                else
                {
                    if (textIndex == exitIndex)
                    {
                        FinishInteracting(true);
                    }
                    else
                    {
                        FinishInteracting(false);
                    }
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

        if (enemyManagerManager.EnemyCount != 0) //in the future, this would be a submimic of mimics, but right now we just have one
        {
            textIndex = 9;
        }
    }

    public override void FinishInteracting(bool dialogComplete)
    {
        isActiveObject = false;
        textArray[textIndex].enabled = false;
        timer = 0;

        if (dialogComplete || isFinished) //if you're done, you're not going back
        {
            //this is where a mimic would give you an item or powerup
            textIndex = exitIndex - 1;
            isFinished = true;
        }
        else
        {
            //you left mid conversation you jerk, no item for you

            closedChestSprite.enabled = true;
            openChestSprite.enabled = false;
            textIndex = -1;
        }
    }

    public override void Overlay()
    {
        overlayText.enabled = true;
    }
}
