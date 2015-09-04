using UnityEngine;
using System.Collections;

public class GameOver : PlayerLives {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void GameOverScreen()
	{
		if (lives < 1) {
			Application.LoadLevel(3);
		}
	}
}
