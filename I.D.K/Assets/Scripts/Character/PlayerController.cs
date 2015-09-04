using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movement Related
	public float speed;
	public float jumpSpeed;
	private float jumpCount;
	private float maxJump = 2;
	
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
		if (jumpCount < maxJump) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				this.GetComponent<Rigidbody>().velocity = new Vector3 (0, jumpSpeed, 0);
				jumpCount++;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		//Jumping
		if (other.transform.tag == "Ground") 
		{
			jumpCount = 0;
		}
	}
}