using UnityEngine;
using System.Collections;

public class RandomPos : MonoBehaviour {
	private Vector3 _randomPos;
	public float xMin = 0f;
	public float xMax = 11f;
	public float yMin = -3.5f;
	public float ymax = 3.5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		_randomPos = new Vector3 (Random.Range(xMin,xMax), Random.Range (yMin, ymax));
		transform.position = _randomPos;
	}
}
