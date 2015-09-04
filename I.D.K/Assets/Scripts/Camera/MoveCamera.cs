using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public float speed;

	void Update () {
		transform.Translate (Vector2.right * Time.deltaTime * speed);
	}
}
