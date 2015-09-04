using UnityEngine;
using System.Collections;

public class IntroDelay : MonoBehaviour {
	public float delayTime = 5;
	void Update()
	{
		if (Input.anyKey) {
			Application.LoadLevel (1);
		}
	}

	IEnumerator Start ()
	{
		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel (1);
	}
}
