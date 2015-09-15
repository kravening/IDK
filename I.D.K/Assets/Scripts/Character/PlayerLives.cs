using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	public float lives;
	private float maxLives = 3;
	// Use this for initialization
	void Start () {
		lives = maxLives;
		Debug.Log (lives);
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
		if (lives < 1) 
		{
			Destroy(this.gameObject);
		}
	}
}
