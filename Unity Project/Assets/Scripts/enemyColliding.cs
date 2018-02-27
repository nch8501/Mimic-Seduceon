using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyColliding : MonoBehaviour {
    public int col = 10;

    public void Start()
    {
        col = 100;
    }



    //check if enemy is colliding with something
    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if player sword is being used



        Debug.Log("Colliding");
    }


}
