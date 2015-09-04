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
//		GameOver ();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy") 
		{
			lives = lives-1;
			Debug.Log(lives);
		}
	}

/*	IEnumerator GameOver()
	{
		if (lives < 1) 
		{
			//add a dying animation

			//Load Gameover screen
			//yield return new WaitForSeconds(2);
			Application.LoadLevel("Game_Over");
		}
	}*/
}
