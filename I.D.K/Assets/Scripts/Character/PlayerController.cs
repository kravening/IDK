using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movement Related
	public float speed;
	public int cooldownAmount = 60;
	public GameObject bullet;
	public ParticleSystemRenderer muzzleFlash;
	public ParticleSystemRenderer explosion;
	public Transform firePoint;
	private int bulletCooldown;
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
        if (Input.GetKey(KeyCode.A))//Move Left
        {
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
        if (Input.GetKey(KeyCode.D))//Move Right
        {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
        if (Input.GetKey(KeyCode.W))//Move Up
        {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
        if (Input.GetKey(KeyCode.S))//Move Down
        {
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
		
        if (shoot) {
			if (bulletCooldown >= cooldownAmount) {
				SpawnBullet ();
				bulletCooldown = 0;
			}
		}
		bulletCooldown++;
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			shoot = true;
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

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "Ground") 
		{
			Debug.Log ("get rekt");
			Instantiate (explosion, firePoint.position,Quaternion.Euler(0,0,0));
			Destroy(this.gameObject);
		}
	}
}