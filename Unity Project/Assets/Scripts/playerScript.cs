using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {


    public int health; //player's health

    float invincibilityFrames;  //how long invincibility lasts
    bool isInvincible;  //if the player is invincible
    public SpriteRenderer[] healthBar;

    SpriteRenderer playerSpriteRenderer;    //player's sprite renderer

	// Use this for initialization
	void Start () {

        //setup health
        health = 5;

        //setup invincibility
        invincibilityFrames = 0.0f;
        isInvincible = false;

        //get the sprite's renderer
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        //check and handle Invincibility
        Invincibility();
        //CheckHealth();
	}

    //checks for collisions
    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if colliding wiith enemy
        EnemyCollision(collision);


    }

    //temporarily makes the player invincible
    void Invincibility()
    {
        //check if player is invincible
        if(isInvincible)
        {
            //check if enough time has passed
            if (invincibilityFrames >= 0.75f)
            {
                //reset invincibility
                invincibilityFrames = 0.0f;
                isInvincible = false;

                //reset sprite color
                playerSpriteRenderer.color = Color.white;
            }
            else
            {
                //increase frames
                invincibilityFrames += Time.deltaTime;
            }
        }
    }

    //checks if player is colliding with Enemies
    void EnemyCollision(Collider2D collision)
    {
        //check if colliding with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            //check if player is invincible
            if(!isInvincible)
            {
                //decrement health
                health--;

                //change healthbar
                if (health >= 0)
                {
                    healthBar[health + 1].enabled = false;
                    healthBar[health].enabled = true;
                }

                //make player invincible
                isInvincible = true;

                //make player red
                playerSpriteRenderer.color = Color.red;
                
            }


        }
    }

    /// <summary>
    /// Checks if Enemy Health has been reduced to 0
    /// </summary>
    void CheckHealth()
    {
        if (health <= 0)
        {
            //enemy is dead, destroy it
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }


}
