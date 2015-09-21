using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveOnCollision : MonoBehaviour 
{

	[Header("Enter tags")]
	public List<string> tags = new List<string>();
	private int _listLength;
	// Use this for initialization
	void Start () {
		_listLength = this.tags.Count;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D kill){

		if (kill.transform.tag == tags[0]){
			Destroy(this.gameObject);
			Debug.Log ("hallo");

		}
	}

}
