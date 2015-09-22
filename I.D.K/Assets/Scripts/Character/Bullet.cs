using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	private float _speed;
	public float acceleration;
	public ParticleSystemRenderer impact;
	
	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector2.right * Time.deltaTime * _speed);
		_speed += acceleration;
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
	
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.GetComponent<EnemyController> ().DestroyEnemy();
			Destroy (this.gameObject);
		}

		if (coll.transform.tag == "BulletStopper") {
			Destroy (this.gameObject);
		}


	}

}

