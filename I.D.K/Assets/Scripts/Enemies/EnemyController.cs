using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float _speed = 3.5f;
    public int enemyHealth;

	// Use this for initialization
	void Start () {
        enemyHealth = 2;
    }
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * Time.deltaTime * _speed);
	}

    void OnCollisionEnter2D(Collision2D other){
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
	}
}
