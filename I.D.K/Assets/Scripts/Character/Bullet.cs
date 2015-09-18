using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private float speed;
    public float acceleration;
    public int lifeSpan;

    private ScoreManager _scoreManager;
	
    // Use this for initialization
    void Start()
    {
        _scoreManager = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        speed += acceleration;
        if (lifeSpan < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lifeSpan--;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            _scoreManager.AddScore(50);
            print("colliding");
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
        if (coll.transform.tag == "BulletStopper")
        {
            Debug.Log("Stopper");
            Destroy(this.gameObject);
        }
    }

}

