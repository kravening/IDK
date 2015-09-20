using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {
	public float speed;
	public float acceleration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * speed);
		speed += acceleration;
	
	}
}
