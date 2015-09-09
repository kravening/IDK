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
	
	// Update is called once per frame
	void Update () {
		if (lives < 1) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Ground") 
		{
			DamageTaken(3);
			Debug.Log(lives);
		}
		if (other.transform.tag == "Enemy") 
		{
			DamageTaken(1);
			Debug.Log(lives);
		}
	}

	void DamageTaken(int damageTaken)
	{
		lives -= damageTaken;
	}
}
