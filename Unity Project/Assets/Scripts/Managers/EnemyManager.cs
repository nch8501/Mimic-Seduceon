using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script holds all of the current enemies in the game
public class EnemyManager : MonoBehaviour {

    // Fields
    // All Types of Enemy prefab
    [SerializeField]
    private GameObject[] enemyPrefabs;

    // Array of places for enemies to spawn
    [SerializeField]
    private GameObject[] spawnPoints;

    public List<GameObject> enemies = new List<GameObject>();   //list of all active enemies


	// Use this for initialization
	void Start () {
        // Spawn a random enemy at each of the spawn points
        Quaternion zero = Quaternion.Euler(0, 0, 0);
        foreach (GameObject spawner in spawnPoints)
        {
            enemies.Add(Instantiate(RandomEnemyPrefab(), spawner.transform.position,zero));
        }
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
