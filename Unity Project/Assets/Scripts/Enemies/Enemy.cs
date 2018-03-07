using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject playerObject; //the player Gameobject
    public GameObject playerWeapon; //the player weapon Gameobject

    public int health; //enemy's health

    [SerializeField]
    private float SPEED;

    public bool isInvincible;
    public float invincibilityFrames;




	// Use this for initialization
	void Start () {
        //setup playerObject
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //setup player weapon
        playerWeapon = playerObject.transform.GetChild(0).transform.GetChild(0).gameObject;

        health = 2;

        //setup Invincibility
        isInvincible = false;
        invincibilityFrames = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        CheckHealth();
	}

    //check if enemy is colliding with something
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //check if player sword is being used
        if (collision.gameObject == playerWeapon)
        {
            if(playerWeapon.GetComponent<WeaponScript>().isAttacking)
            {
                //if enemy is not invincible
                if (!isInvincible)
                {
                    health--;
                }


                //enemy has been hit
                Invincibility();

                
            }   
        }
    }

    //Checks if Enemy Health has been reduced to 0
    void CheckHealth()
    {
        if(health <= 0)
        {
            //enemy is dead, destroy it
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Move the Enemy toward the player
    /// </summary>
    void Movement()
    {
        // Get the vector from the enemy to the player
        Vector3 direction = Vector3.zero;
        direction += playerObject.transform.position - transform.position;

        // Make the vector speed long
        direction = direction.normalized * SPEED;

        // Add to the player as time dependent
        transform.position += direction * Time.deltaTime;
    }

    //temporarily makes the enemy invincible
    void Invincibility()
    {
        //make enemy invincible
        isInvincible = true;

        //check if enough time has passed
        if(invincibilityFrames >= 0.125f)
        {
            //reset invincibility
            invincibilityFrames = 0.0f;
            isInvincible = false;
        }
        else
        {
            Debug.Log("invincible");
            invincibilityFrames += Time.deltaTime;
        }
    }

}
