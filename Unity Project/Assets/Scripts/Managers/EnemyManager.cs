﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script holds all of the current enemies in the game
public class EnemyManager : MonoBehaviour {

    // Fields
    // All Types of Enemy prefab
    [SerializeField]
    private GameObject[] enemyPrefabs;

    public List<GameObject> enemies = new List<GameObject>();   //list of all active enemies


	// Use this for initialization
	void Start () {


        //create some enemies
        Vector3 pos = new Vector3(2.0f, 0.0f, 0.0f);
        Quaternion quat = new Quaternion();
   
        GameObject temp = Instantiate(RandomEnemyPrefab(), pos, quat);
        //add enemy to enemies
        enemies.Add(temp);

        pos.Set(1.0f, 4.0f, 0.0f);
        temp = Instantiate(RandomEnemyPrefab(), pos, quat);
        enemies.Add(temp);

        pos.Set(-2.0f, 0.0f, 0.0f);
        temp = Instantiate(RandomEnemyPrefab(), pos, quat);
        enemies.Add(temp);

        pos.Set(-5.0f, -1.0f, 0.0f);
        temp = Instantiate(RandomEnemyPrefab(), pos, quat);
        enemies.Add(temp);
    }
	
	// Update is called once per frame
	void Update () {

        CheckDestroyed();
		
	}

    //Adds an enemy to the Enemies List
    void AddEnemy(GameObject enemy, Vector3 pos)
    {
        Quaternion quat = new Quaternion();

        //Instantiate the enemy
        GameObject temp = Instantiate(enemy, pos, quat);

        //Add the enemy
        enemies.Add(temp);
    }

    //Removes an enemy from the Enemies List
    void RemoveEnemy(int index)
    {
        enemies.RemoveAt(index);
    }

    //Checks if any enemies have been destroyed
    void CheckDestroyed()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] == null)
            {
                //remove enemy from list
                RemoveEnemy(i);

                //decrement i, since enemy count has lowered
                i--;
            }
        }
    }

    /// <summary>
    /// Get a random enemy from the prefab array
    /// </summary>
    /// <returns>An Enemy from the Prefab array</returns>
    private GameObject RandomEnemyPrefab()
    {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
    }
}
