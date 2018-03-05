using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    //weapon object
    public GameObject weaponObject;
    GameObject playerObject;

    //whether or not the weapon is attacking
    public bool isAttacking;

    public float attackWindow;


	// Use this for initialization
	void Start () {

        isAttacking = false;
        attackWindow = 0.0f;
        weaponObject.GetComponent<SpriteRenderer>().enabled = false;
        weaponObject.GetComponent<BoxCollider2D>().enabled = false;

        playerObject = GameObject.FindGameObjectWithTag("PlayerSprite");
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //check if attacking
        if(isAttacking)
        {
            weaponObject.GetComponent<BoxCollider2D>().enabled = true;

            //check if attackWindow is gone
            if (attackWindow <= 0.0f)
            {
                StopAttacking();
            }
            else
            {
                //decrease attackWindow
                attackWindow -= .1f;
            }
        }
        else
        {
            //check if attacking
            Attacking();
        }
	}


    void Attacking()
    {
        //check if spacebar is pressed
        if(Input.GetKey(KeyCode.Space))
        {
            //set isAttacking to true
            isAttacking = true;
            weaponObject.GetComponent<SpriteRenderer>().enabled = true;

            //increase attackWindow
            attackWindow = 2.0f;
        }
    }

    void StopAttacking()
    {
        isAttacking = false;
        weaponObject.GetComponent<SpriteRenderer>().enabled = false;
        weaponObject.GetComponent<BoxCollider2D>().enabled = false;
        attackWindow = 0.0f;
    }



}
