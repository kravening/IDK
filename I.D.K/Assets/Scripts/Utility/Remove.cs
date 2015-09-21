using UnityEngine;
using System.Collections;

public class Remove : MonoBehaviour {
	private int _counter;
	public int lifeSpan;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_counter++;
		if(_counter > lifeSpan){
			Destroy(this.gameObject);
		}
	
	}
}
