using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	public int lives;
	private int maxLives = 3;
    public ParticleSystemRenderer explosion;
    public Transform firePoint;
	
   // Use this for initialization
	void Start () {
		lives = maxLives;
        Debug.Log(lives);
	}

    void Update()
    {
        /*if (lives < 1)
        {
            StartCoroutine(GameOver());
        }*/
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Ground") 
		{
			DamageTaken(3);
			Debug.Log(lives);
		}
        GameOver();
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            DamageTaken(1);
            Debug.Log(lives);
        }
        GameOver();
    }

	void DamageTaken(int damageTaken)
	{
		lives -= damageTaken;
	}

    void GameOver()
    {
        if (lives < 1)
        {
            Instantiate(explosion, firePoint.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
            Time.timeScale = 0.2f;
        }
    }
}
