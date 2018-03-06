using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemyScript : MonoBehaviour {

    public GameObject baseEnemyObject;  //this Gameobject


    public GameObject playerObject; //the player Gameobject
    public GameObject playerWeapon; //the player weapon Gameobject

    public int health; //enemy's health
    private const float SPEED = 2.5f; // NYOOM


	// Use this for initialization
	void Start () {
        //setup playerObject
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //setup player weapon
        playerWeapon = playerObject.transform.GetChild(0).transform.GetChild(0).gameObject;

        health = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        CheckHealth();
	}

    //check if enemy is colliding with something
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        //check if player sword is being used
        if (collision.gameObject == playerWeapon)
        {
            if(playerWeapon.GetComponent<WeaponScript>().isAttacking)
            {
                //enemy has been hit
                health--;
            }   
        }
    }

    //Checks if Enemy Health has been reduced to 0
    void CheckHealth()
    {
        if(health <= 0)
        {
            //enemy is dead, destroy it
            Destroy(baseEnemyObject);
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
}
