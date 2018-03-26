using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the Camera
public class cameraController : MonoBehaviour {

    GameObject playerObject;    //player

    // Use this for initialization
    void Start () {
        //setup playerObject
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        CameraDistance();
	}

    //checks if the player is too far from the camera and moves it
    void CameraDistance()
    {
        Vector3 playerPos = playerObject.transform.position;

        float xBuffer = 3.0f;
        float yBuffer = 1.5f;

        if(playerPos.x - transform.position.x >= xBuffer)
        {
            //move camera
            transform.position += new Vector3(0.09f, 0.0f, 0.0f);
        }
        if(transform.position.x - playerPos.x >= xBuffer)
        {
            //move camera
            transform.position -= new Vector3(0.09f, 0.0f, 0.0f);
        }

        if (playerPos.y - transform.position.y >= yBuffer)
        {
            //move camera
            transform.position += new Vector3(0.0f, 0.09f, 0.0f);
        }
        if (transform.position.y - playerPos.y >= yBuffer)
        {
            //move camera
            transform.position -= new Vector3(0.0f, 0.09f, 0.0f);
        }
    }
}
