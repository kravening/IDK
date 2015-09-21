using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private float _speed;
    public float acceleration;
	public ParticleSystemRenderer impact;
	public ParticleSystemRenderer enemyExplodes;

    private ScoreManager _scoreManager;
	
    // Use this for initialization
    void Start()
    {
        _scoreManager = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
        _speed += acceleration;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (this.gameObject != null) {
			if (coll.gameObject.tag == "Enemy") {
				if (coll.gameObject != null) {

					int eHealth = coll.gameObject.GetComponent<EnemyController> ().enemyHealth;

					if (eHealth <= 1) {
						Instantiate (enemyExplodes, coll.transform.position, Quaternion.Euler (0, 0, 0));
						Destroy (coll.gameObject);
						_scoreManager.AddScore (50);
					} else {
						coll.gameObject.GetComponent<EnemyController> ().enemyHealth -= 1;
					}
					Instantiate (impact, this.gameObject.transform.position, Quaternion.Euler (0, 0, 0));
					Destroy (this.gameObject);
				}
			}
			if (coll.transform.tag == "BulletStopper") {
				Debug.Log ("Stopper");
				Destroy (this.gameObject);
			}
		}
    }

}

