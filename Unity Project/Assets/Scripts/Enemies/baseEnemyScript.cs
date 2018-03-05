using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemyScript : MonoBehaviour {

    public GameObject baseEnemyObject;  //this Gameobject


    public GameObject playerObject; //the player Gameobject
    public GameObject playerWeapon; //the player weapon Gameobject

    public int health; //enemy's health


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



}
