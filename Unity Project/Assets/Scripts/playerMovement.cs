using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject playerObject;   //the player object
    public GameObject playerSprite;   //the player sprite





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        RotateTowardsMouse();
		
	}

    //controls player movement
    void Movement()
    {
        //check keyboard input
        if(Input.anyKey)
        {
            //y movement
            if (Input.GetKey(KeyCode.W))
            {
                playerObject.transform.Translate(0.0f, 0.1f, 0.0f);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                playerObject.transform.Translate(0.0f, -0.1f, 0.0f);
            }

            //x movement
            if (Input.GetKey(KeyCode.D))
            {
                playerObject.transform.Translate(0.1f, 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerObject.transform.Translate(-0.1f, 0.0f, 0.0f);
            }
        }
    }

    //controls player direction
    void RotateTowardsMouse()
    {
        //get mouse location
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //get player's current position
        Vector3 playerPos = Camera.main.WorldToViewportPoint(playerObject.transform.position);

        //find angle between these
        float angle = Mathf.Atan2(playerPos.y - mousePos.y, playerPos.x - mousePos.x) * Mathf.Rad2Deg;

        //set player angle
        playerSprite.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));



    }




}
