using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject playerObject;   //the player object
    public GameObject playerSprite;   //the player sprite

    [SerializeField]
    private float speed;



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
            /**if (Input.GetMouseButton(1)) //Code for mouse movement, 100% needs to be optimized if used
            {
                Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                Vector3 playerPos = Camera.main.WorldToViewportPoint(playerObject.transform.position);

                Vector2 translateVector = mousePos - new Vector2(playerPos.x, playerPos.y);
                translateVector.Normalize();
                translateVector /= 10;

                playerObject.transform.Translate(translateVector);
            }**/

            Vector3 movement = Vector3.zero;
            //y movement
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.up;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                movement += Vector3.down;
            }

            //x movement
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement += Vector3.left;
            }

            transform.position+=movement.normalized * speed * Time.deltaTime;
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
        float angle = Mathf.Atan2(playerPos.y - mousePos.y, playerPos.x - mousePos.x) * Mathf.Rad2Deg + 90;

        //set player angle
        playerSprite.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));



    }




}
