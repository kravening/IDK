﻿using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	private float _speed;
	public float acceleration;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector2.right * Time.deltaTime * _speed);
		_speed += acceleration;
	
	}
}