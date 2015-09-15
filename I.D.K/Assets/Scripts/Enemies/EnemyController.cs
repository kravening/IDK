using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float speed = 3.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * Time.deltaTime * speed);
	}
	void OnCollisionEnter2D(Collision2D other){
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
	}
}
