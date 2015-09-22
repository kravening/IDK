using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public ParticleSystemRenderer muzzleFlash;
	public ParticleSystemRenderer bulletSmoke;
	public ParticleSystemRenderer enemyExplodes;
	public GameObject bullet;
	public Transform firePoint;

    private int enemyHealth;
	private int _countdownTimer = 100;
    private ScoreManager _scoreManager;
	private bool _isInStartPos = false;
	private bool _snapshotPosition = false;
	private Transform _randomPos;
	private Transform _player;
	private Transform _rotateToThis;
	private Vector3 _direction;
	private float _diveSpeed = 0;
	private float _diveAcceleration = .30f;
	private float _cameraWidth;
	private float _cameraHeight;
	public bool diveOn = true;
	public bool shootOn = true;

	void Start () {
		_cameraWidth = Camera.main.orthographicSize / Camera.main.pixelHeight * Camera.main.pixelWidth;
		if (shootOn == false) {
			_diveAcceleration = .60f;
		}
		enemyHealth = 2;
		_scoreManager = GameObject.Find ("ScoreText").GetComponent<ScoreManager> ();
    }
	
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
		transform.rotation = Quaternion.Euler (0, 0, zAngle);
	}

	void Kamikaze(){ //if countdown is 0 dive onto player position
		_countdownTimer--;
		if (_countdownTimer <= 0) {
			if(_snapshotPosition == false){
				GetPos(_player, "Player");
				_snapshotPosition = true;
			}
			transform.Translate(Vector2.right * _diveSpeed * Time.deltaTime);
			_diveSpeed += _diveAcceleration;
		}
	}

	void SpawnBullet(){
		Instantiate (muzzleFlash, firePoint.position,Quaternion.Euler(0,0,-180));
		Instantiate (bulletSmoke, firePoint.position,Quaternion.Euler(0,-90,-180));
		Instantiate (bullet,firePoint.position,Quaternion.Euler(0,0,-180));
		
	}

	public void DestroyEnemy(){
		if (enemyHealth <= 0) {
			_scoreManager.AddScore (50);
			Instantiate (enemyExplodes, this.gameObject.transform.position, Quaternion.Euler (0, 0, 0));
			Destroy (this.gameObject);
		} else {
			enemyHealth--;
		}
	}
}
