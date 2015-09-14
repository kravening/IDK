using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    [Header("Enemy set prefabs")]
    public List<GameObject> enemySet = new List<GameObject>();
    public float enemySpeed;
    public Transform enemySpawner;
    public float spawnCooldown =2;
    public int cooldownSpawner = 0;
    private int counter = 0;
    //public float numberOfEnemiesSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
        //SpawnEnemy();
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

/*    void SpawnEnemy()
    {
        if(counter >= cooldownSpawner){
          //SpawnCooldown();
             Debug.Log("Spawned enemy");
            Instantiate(,enemySpawner.position,Quaternion.Euler(0,0,0));
            counter= 0;

        }else{
            counter++;
        }
        
    }
*/
    private GameObject getRandomEnemySet(Vector3 _position)
    {
        return spawnEnemySet(enemySet[Random.Range(0, enemySet.Count)], _position);
    }

    private GameObject spawnEnemySet(GameObject _enemy, Vector3 _position)
    {
         if(counter >= cooldownSpawner){
          //SpawnCooldown();
             Debug.Log("Spawned enemy");
             Instantiate(_enemy,enemySpawner.position,Quaternion.Euler(0,0,0));
             counter = 0;

         }else
         {
            counter++;
         }
        
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
    }
}
