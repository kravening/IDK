using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
    public List<GameObject> enemyChunks = new List<GameObject>();
    public GameObject enemy;
	// Use this for initialization
	void Start () 
    {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void Spawn()
    {
        for (int i = 0; i < enemyChunks.Count; i++)
        {
            enemyChunks.Add(enemy);
            Debug.Log(enemyChunks.Count);
        }
    }

}
