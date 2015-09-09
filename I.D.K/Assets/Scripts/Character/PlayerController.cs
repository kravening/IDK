using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movement Related
	public float speed;
	public float jumpSpeed;
	private float jumpCount;
	private float maxJump = 2;
	private float xPos;
	private float yPos;
	private bool moveRight = false;
	private bool moveLeft = false;
	private bool moveUp = false;
	private bool moveDown = false;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement()
	{
		if (moveLeft) {
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		if (moveRight) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		if (moveUp) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		if (moveDown) {
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.D)) { //move right
			moveRight = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) { //move left
			moveLeft = true;
		}
		if (Input.GetKeyDown (KeyCode.W)) { //move up
			moveUp = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) { //move down
			moveDown = true;
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			moveRight = false;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			moveLeft = false;
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			moveUp = false;
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			moveDown = false;
		}
		//Automatic Movement to the right
		//Jump
		if (jumpCount < maxJump) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				//this.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, jumpSpeed,0);
				jumpCount++;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Ground") 
		{
			Debug.Log ("get rekt");
			Destroy(this);
		}
	}
}