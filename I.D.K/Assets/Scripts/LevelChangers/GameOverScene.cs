using UnityEngine;
using System.Collections;

public class GameOverScene : MonoBehaviour {

    private GameObject _player;
    private string _gameOver = "Game_Over";
    
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(GameOver());
	}

    IEnumerator GameOver()
    {
        if(_player == null)
        {
            yield return new WaitForSeconds(0.5f);
            Application.LoadLevel(_gameOver);
        }else
        {
            Time.timeScale = 1;
        }

    }
}
