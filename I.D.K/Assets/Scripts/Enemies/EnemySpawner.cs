using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float xMin = 13;
    private float xMax = 17;
    private float yMin = 0;
    private float yMax = 1;

    private float spawnCooldown = 4;
    private float timeUntilSpawn = 4;

    public GameObject[] enemyPrefabs;
   // Use this for initialization
	void Start () {
        for (int i = 0; i < 1; i++)
        {
            SpawnEnemy();
        }
	}
	
	// Update is called once per frame
	void Update () {
	         timeUntilSpawn -= Time.deltaTime;
     if(timeUntilSpawn <= 0)
     {
         // Do your enemy spawns here
         SpawnEnemy();
         // Reset for next spawn
         timeUntilSpawn = spawnCooldown;
     }
	}

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
	
        Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
        GameObject enemySet = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
    }
}
