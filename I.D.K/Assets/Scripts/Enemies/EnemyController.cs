using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float _speed = 3.5f;
    private ScoreManager _scoreManager;
	// Use this for initialization
	void Start () {
        _scoreManager = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * Time.deltaTime * _speed);

	}
	void OnCollisionEnter2D(Collision2D other){
        _scoreManager.AddScore(50);

        if (other.transform.tag == "Player")
        {
            
            Debug.Log("Added");
            Destroy(this.gameObject);
        }
	}
}
