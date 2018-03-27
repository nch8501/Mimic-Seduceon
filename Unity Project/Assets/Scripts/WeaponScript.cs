using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    //weapon object
    public GameObject weaponObject;
    GameObject playerObject;
    public playerMovement actualPlayerObject;

    //whether or not the weapon is attacking
    public bool isAttacking;

    public float attackWindow;

    //Swing variables
    public float swingSpeed = 5.0f;
    public float swingRadius = 3.0f;
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
		if (!isAttacking && !actualPlayerObject.IsInteracting)
        {
            //check if attacking
            AttackCheck();
        }
        //check if attacking
        if (isAttacking)
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
	}


    void AttackCheck()
    {
        //check if spacebar is pressed
        if(Input.GetButton("Attack") && attackWindow <= 0.0f)
        {
            //set isAttacking to true
            isAttacking = true;
            weaponObject.GetComponent<SpriteRenderer>().enabled = true;

            //weaponObject.GetComponent<Transform>().rotation = startingRotation;
            weaponObject.GetComponent<Transform>().localPosition = startingPosition;//(playerObject.GetComponent<Transform>().up + startingPosition);
            
            //increase attackWindow
            attackWindow = 1.0f;
        }
    }

    void Attack()
    {
        //Vector3 rotationAxis = playerObject.GetComponent<Transform>().localPosition;
       // weaponObject.GetComponent<Transform>().Rotate(0, 0, 5.0f, Space.Self);

        swingAngle -= swingSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(swingAngle), Mathf.Cos(swingAngle), 0) * swingRadius;
        weaponObject.GetComponent<Transform>().localPosition = playerObject.GetComponent<Transform>().localPosition + offset;


        
        if (weaponObject.transform.position.y < playerObject.transform.position.y)
        {
            weaponObject.transform.right = playerObject.transform.localPosition - weaponObject.transform.localPosition;
        }
        else
        {
            weaponObject.transform.right = -(playerObject.transform.localPosition - weaponObject.transform.localPosition); //flips sword while upside down, change this later
        }

        //Vector3 target = playerObject.GetComponent<Transform>().localPosition - weaponObject.GetComponent<Transform>().localPosition;
        //weaponObject.GetComponent<Transform>().LookAt(target);


        //Vector3 vectorToTarget = playerObject.GetComponent<Transform>().position - weaponObject.GetComponent<Transform>().position;
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 0);
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
