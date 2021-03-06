﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int cooldownAmount = 60;
	public GameObject bullet;
	public ParticleSystemRenderer muzzleFlash;
	public ParticleSystemRenderer bulletSmoke;
	public Transform firePoint;
	private int bulletCooldown;
	private bool shoot = false;
	private AudioSource audio;
	public AudioClip shootAudio;

	void Start(){
		audio = GetComponent<AudioSource>();
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
		audio.clip = shootAudio;
		audio.Play ();
		Instantiate (muzzleFlash, firePoint.position,Quaternion.Euler(0,0,0));
		Instantiate (bulletSmoke, firePoint.position,Quaternion.Euler(0,-90,0));
		Instantiate (bullet,firePoint.position,transform.rotation);

	}
}