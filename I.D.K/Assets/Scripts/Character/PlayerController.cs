using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movement Related
	public float speed;
	public float jumpSpeed;
	public int cooldownAmount = 60;
	public GameObject bullet;
	public ParticleSystemRenderer muzzleFlash;
	public ParticleSystemRenderer explosion;
	public Transform firePoint;
	private float jumpCount;
	private float maxJump = 2;
	private int bulletCooldown;
	private bool moveRight = false;
	private bool moveLeft = false;
	private bool moveUp = false;
	private bool moveDown = false;
	private bool shoot = false;

	
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
		if (shoot) {
			if (bulletCooldown >= cooldownAmount) {
				SpawnBullet ();
				bulletCooldown = 0;
			}
		}
		bulletCooldown++;
		

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
		if (Input.GetKeyDown (KeyCode.Space)) {
			shoot = true;
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
		if (Input.GetKeyUp (KeyCode.Space)) {
			shoot = false;
		}
	}

	void SpawnBullet(){
		Debug.Log ("lekker knallen");
		Instantiate (muzzleFlash, firePoint.position,Quaternion.Euler(0,0,0));
		Instantiate (bullet,firePoint.position,transform.rotation);

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Ground") 
		{
			Debug.Log ("get rekt");
			Instantiate (muzzleFlash, firePoint.position,Quaternion.Euler(0,0,0));
			Destroy(this);
		}
	}
}