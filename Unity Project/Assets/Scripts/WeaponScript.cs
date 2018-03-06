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

    //Swing variables
    public float swingSpeed = 5.0f;
    public float swingRadius = 1.0f;
    private float swingAngle = 0.0f;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

	// Use this for initialization
	void Start () {

        isAttacking = false;
        attackWindow = 0.0f;
        weaponObject.GetComponent<SpriteRenderer>().enabled = false;
        weaponObject.GetComponent<BoxCollider2D>().enabled = false;

        playerObject = GameObject.FindGameObjectWithTag("PlayerSprite");

        startingPosition = weaponObject.GetComponent<Transform>().localPosition;
        startingRotation = weaponObject.GetComponent<Transform>().rotation;
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
                Attack();
                attackWindow -= .1f;
            }
        }
        else
        {
            //check if attacking
            AttackCheck();
        }
	}


    void AttackCheck()
    {
        //check if spacebar is pressed
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackWindow <= 0.0f)
        {
            //set isAttacking to true
            isAttacking = true;
            weaponObject.GetComponent<SpriteRenderer>().enabled = true;

            weaponObject.GetComponent<Transform>().rotation = startingRotation;
            weaponObject.GetComponent<Transform>().position = (playerObject.GetComponent<Transform>().up + startingPosition);

            //increase attackWindow
            attackWindow = 1.0f;
        }
    }

    void Attack()
    {
        //Vector3 rotationAxis = playerObject.GetComponent<Transform>().position;
        //weaponObject.GetComponent<Transform>().Rotate(0, 0, 5.0f, Space.Self);

        swingAngle -= swingSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(swingAngle), Mathf.Cos(swingAngle), 0) * swingRadius;
        weaponObject.GetComponent<Transform>().localPosition = playerObject.GetComponent<Transform>().position + offset;

        //weaponObject.GetComponent<Transform>().localPosition = Vector3.Slerp(startingPosition, (startingPosition - new Vector3(-2, 0, -20)), 0.1f);
    }

    void StopAttacking()
    {
        isAttacking = false;
        weaponObject.GetComponent<SpriteRenderer>().enabled = false;
        weaponObject.GetComponent<BoxCollider2D>().enabled = false;
        attackWindow = 0.0f;
        swingAngle = 0.0f;
    }



}
