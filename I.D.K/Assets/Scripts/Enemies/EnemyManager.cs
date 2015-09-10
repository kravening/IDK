using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float enemySpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
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
}
