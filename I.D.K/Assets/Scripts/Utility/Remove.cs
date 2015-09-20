using UnityEngine;
using System.Collections;

public class Remove : MonoBehaviour {
	private int counter;
	public int lifeSpan;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if(counter > lifeSpan){
			Destroy(this.gameObject);
		}
	
	}
}
