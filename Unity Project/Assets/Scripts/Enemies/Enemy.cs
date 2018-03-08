using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Purpose: Basic Enemy class (to be inheritied)
    // Limitations: None

    public GameObject playerObject; //the player Gameobject
    public GameObject playerWeapon; //the player weapon Gameobject

    public int health; //enemy's health

    [SerializeField]
    private float SPEED;

    public bool isInvincible;
    public float invincibilityFrames;

    // Use this for initialization
    protected virtual void Start(int health)
    {
        //setup playerObject
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //setup player weapon
        playerWeapon = playerObject.transform.GetChild(0).transform.GetChild(0).gameObject;

        this.health = health;

        //setup Invincibility
        isInvincible = false;
        invincibilityFrames = 0.0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Movement();
        Invincibility();
        CheckHealth();
    }

    //check if enemy is colliding with something
    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Colliding");
        print(collision);
        //check if player sword is being used
        if (collision.gameObject == playerWeapon)
        {
            print("Player hit");

            if (playerWeapon.GetComponent<WeaponScript>().isAttacking)
            {
                //if enemy is not invincible
                if (!isInvincible)
                {
                    health--;
                    isInvincible = true;
                    KnockBack();
                }
            }
            Debug.Log("Hit");

            //enemy has been hit
            Invincibility();
        }
    }

    /// <summary>
    /// Checks if Enemy Health has been reduced to 0
    /// </summary>
    void CheckHealth()
    {
        if (health <= 0)
        {
            //enemy is dead, destroy it
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Move the Enemy toward the player
    /// </summary>
    protected virtual void Movement()
    {
        // Get the vector from the enemy to the player
        Vector3 direction = Vector3.zero;
        direction += playerObject.transform.position - transform.position;

        // Make the vector speed long
        direction = direction.normalized * SPEED;

        // Add to the player as time dependent
        transform.position += direction * Time.deltaTime;
    }


    /// <summary>
    /// Check and handle for invincibility
    /// </summary>
    protected void Invincibility()
    {
        //check if player is invincible
        if (isInvincible)
        {
            //check if enough time has passed
            if (invincibilityFrames >= 0.175f)
            {
                //reset invincibility
                invincibilityFrames = 0.0f;
                isInvincible = false;
            }
            else
            {
                //increase frames
                invincibilityFrames += Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// knocks the enemy back from the player
    /// </summary>
    protected void KnockBack()
    {
        //get enemy and player positions
        Vector2 playerPos = playerObject.transform.position;
        Vector2 enemyPos = transform.position;

        //get position difference
        Vector3 difference = enemyPos - playerPos;

        //normalize difference
        difference = difference.normalized;

        //knockback enemy
        transform.position = transform.position + difference;

    }

}
