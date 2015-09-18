using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	public float lives;
	private float maxLives = 3;
    private string gameOver = "Game_Over";
    public ParticleSystemRenderer explosion;
    public Transform firePoint;
	
   // Use this for initialization
	void Start () {
		lives = maxLives;
		Debug.Log (lives);
	}

    void Update()
    {
        if (lives < 1)
        {
            StartCoroutine(GameOver());
        }
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Ground") 
		{
			DamageTaken(3);
			Debug.Log(lives);
		}
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            DamageTaken(1);
            Debug.Log(lives);
        }    
    }

	void DamageTaken(int damageTaken)
	{
		lives -= damageTaken;
	}

    IEnumerator GameOver()
    {      
            Instantiate(explosion, firePoint.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
            yield return new WaitForSeconds(2);
            Application.LoadLevel(gameOver);
            Debug.Log("dead");
    }
}
