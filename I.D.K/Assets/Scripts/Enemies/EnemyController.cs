using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    //private float _speed = 3.5f;
	public ParticleSystemRenderer muzzleFlash;
	public ParticleSystemRenderer bulletSmoke;
	public GameObject bullet;
	public Transform firePoint;

    public int enemyHealth;
	private int _countdownTimer = 100;
    private ScoreManager _scoreManager;
	private bool _isInStartPos = false;
	private bool _startCountdown = false;
	private bool _snapshotPosition = false;
	private Transform _randomPos;
	private Transform _player;
	private Transform _rotateToThis;
	private float _rotSpeed = 90;
	private Vector3 _direction;
	private float diveSpeed = 0;
	private float diveAcceleration = .30f;
	private float _cameraWidth;
	private float _cameraHeight;
	public bool diveOn = true;
	public bool shootOn = true;

	// Use this for initialization
	void Start () {
        enemyHealth = 2;
		_cameraWidth = Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth;
    }
	
	// Update is called once per frame
	void Update () {
		GoToStartPos ();
		OutOfBoundCheck ();
	}

	void OutOfBoundCheck(){
		if (this.gameObject.transform.position.x < 0 - _cameraWidth)
		{
			Destroy(this.gameObject);
		}
	}

    void OnCollisionEnter2D(Collision2D other){
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
	}

	void GoToStartPos(){ // runs if player is not in start position.
		if (_isInStartPos == false) {

			if (this.gameObject.transform.position.x <= 8) { //stop this script if enemy has reached desired position
				_isInStartPos = true;

				if(shootOn)
					SpawnBullet();

			} else {
				transform.Translate (Vector2.left * 5 * Time.deltaTime);
			}
		} else {
			if(diveOn)
				Kamikaze();
		}
	}

	void GetPos(Transform here, string thisObject){ //gets Object position

		if (here == null) {
			GameObject importedObject = GameObject.Find(thisObject); //find Object
			if(importedObject != null){
				here = importedObject.transform;
				//Debug.Log (_rotateToThis);
			}
		}

		if (here == null) {
			return;

		}
		_direction = here.position - transform.position; //Object position placed in this var
		_direction.Normalize();
		RotateTo (_rotateToThis);
	}

	void RotateTo(Transform here){
			
		float zAngle = Mathf.Atan2 (_direction.y, _direction.x) * Mathf.Rad2Deg; //change this if the enemy doesn't look left on spawn.
		//Quaternion desiredRot = Quaternion.Euler(0,0,zAngle);
		transform.rotation = Quaternion.Euler (0, 0, zAngle);
		Debug.Log (zAngle);


	}

	void Kamikaze(){ //if countdown is 0 dive onto player position
		_countdownTimer--;
		if (_countdownTimer <= 0) {
			if(_snapshotPosition == false){
				//_playerPatrols = false; //if you gon kamikaze stop patroling
				GetPos(_player, "Player");
				_snapshotPosition = true;
			}
			transform.Translate(Vector2.right * diveSpeed * Time.deltaTime);
			diveSpeed += diveAcceleration;
		}
	}

	void SpawnBullet(){
		Instantiate (muzzleFlash, firePoint.position,Quaternion.Euler(0,0,-180));
		Instantiate (bulletSmoke, firePoint.position,Quaternion.Euler(0,-90,-180));
		Instantiate (bullet,firePoint.position,Quaternion.Euler(0,0,-180));
		
	}
}
