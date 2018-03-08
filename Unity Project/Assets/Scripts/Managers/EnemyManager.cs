using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script holds all of the current enemies in the game
public class EnemyManager : MonoBehaviour {

    // Fields
    // All Types of Enemy prefab
    [SerializeField]
    private GameObject[] enemyPrefabs;

    // List of places for enemies to spawn
    private Transform[] spawnPoints;

    public List<GameObject> enemies = new List<GameObject>();   //list of all active enemies


	// Use this for initialization
	void Start () {
        // Get the spawn Points
        spawnPoints = gameObject.GetComponentsInChildren<Transform>();

        // Spawn a random enemy at each of the spawn points
        Quaternion zero = Quaternion.Euler(0, 0, 0);
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            GameObject enemy = RandomEnemyPrefab();
            if (enemy != null)
            {
                enemies.Add(Instantiate(enemy, spawnPoints[i].position, zero));
            }
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
    /// <returns>An Enemy from the Prefab array (Null if no enemy)</returns>
    private GameObject RandomEnemyPrefab()
    {
        // Negative 1 represents no enemy
        // NO ENEMY DISABLED
        int enemy = Random.Range(0, enemyPrefabs.Length);
        if (enemy != -1)
        {
            return enemyPrefabs[enemy];
        }
        return null;
    }
}
