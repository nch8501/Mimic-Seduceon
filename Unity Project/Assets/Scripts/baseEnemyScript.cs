using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemyScript : MonoBehaviour {

    public GameObject baseEnemyObject;

    public GameObject playerObject;
    public GameObject playerWeapon;

    public bool colliding;
    public int col = 0;


	// Use this for initialization
	void Start () {
        //setup player weapon
        playerWeapon = playerObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        colliding = true;


	}
	
	// Update is called once per frame
	void Update () {

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
                
                Destroy(baseEnemyObject);
            }
            
        }


        
    }

}
