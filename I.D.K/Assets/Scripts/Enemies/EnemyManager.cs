using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float enemySpeed;
    public GameObject enemy;
    public Transform enemySpawner;
    public float spawnCooldown =2;
    //public float numberOfEnemiesSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
        SpawnEnemy();
	}

    void EnemyMove()
    { 
        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.transform.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }

    void SpawnEnemy()
    {
       Debug.Log("Spawned enemy");
        Instantiate(enemy,enemySpawner.position,Quaternion.Euler(0,0,0));
        SpawnCooldown();
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
    }
}
