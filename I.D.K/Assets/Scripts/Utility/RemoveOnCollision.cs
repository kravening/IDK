using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveOnCollision : MonoBehaviour 
{

	[Header("Enter tags")]
	public List<string> tags = new List<string>();
    private int _listLength;

	void Start () {
		_listLength = this.tags.Count;
    }

	void OnTriggerEnter2D(Collider2D kill){
        if (kill.transform.tag == tags[0])
        {
			Destroy(this.gameObject);
		}
	}
}
