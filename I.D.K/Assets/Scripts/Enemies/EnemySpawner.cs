using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float _xMin = 13;
    private float _xMax = 17;
    private float _yMin = 0;
    private float _yMax = 1;

    private float _spawnCooldown = 4;
    private float _timeUntilSpawn = 4;

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
	         _timeUntilSpawn -= Time.deltaTime;
     if(_timeUntilSpawn <= 0)
     {
         // Do your enemy spawns here
         SpawnEnemy();
         // Reset for next spawn
         _timeUntilSpawn = _spawnCooldown;
     }
	}

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
	
        Vector3 newPos = new Vector3(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax), 0);
        GameObject enemySet = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
    }
}
