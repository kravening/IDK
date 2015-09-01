using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement()
	{
		//Automatic Movement to the right
		transform.Translate (Vector2.right * Time.deltaTime * speed);
		//Jump
		if (isGrounded) 
		{
			if (Input.GetKey (KeyCode.Space)) {
				transform.Translate (Vector2.up * Time.deltaTime * jumpSpeed);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Ground") 
		{
			isGrounded = true;
		}
	}
}