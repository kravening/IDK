using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    private Text _scoreText;
    private int _score = 0;
   // Use this for initialization
	void Start () {
        _scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        SetScore(_score);
	}
	
	// Update is called once per frame
	void Update () {
        SetScore(_score);
	}

    void SetScore(int score)
    {
        _scoreText.text = "SCORE: " + score.ToString();
    }
    public void AddScore(int score)
    {
        _score += score;
        SetScore(_score);
    }
}