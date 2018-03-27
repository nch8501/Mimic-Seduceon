using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManagerManager : MonoBehaviour {

    public List<EnemyManager> managerList;

    public List<EnemyManager> ManagerList
    {
        get { return managerList; }
    }

    public int EnemyCount
    {
        get
        {
            int x = 0;
            for (int i = 0; i < managerList.Count; i++)
            {
                x += managerList[i].enemies.Count;
            }
            return x;
        }
    }

	// Use this for initialization
	void Start () {
        managerList = new List<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsEmpty() //no more enemies
    {
        for (int i = 0; i < managerList.Count; i++)
        {
            if (managerList[i].enemies.Count != 0)
                Debug.Log("Enemycount: " + EnemyCount);
                return false;
        }
        return true;
    }
}
