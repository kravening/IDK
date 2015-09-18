using UnityEngine;
using System.Collections;

public class script2 : MonoBehaviour {
	
	
	public int scoreOfzo = 1;
	public string name; 
	
	// Use this for initialization
	void Start () {
		
		string url = "http://localhost/test3/unity2.php";
		
		//WWWForm form = new WWWForm ();
		
		//form.AddField("Points", scoreOfzo);
		
		//form.AddField("Name", name);
		
		WWW www = new WWW (url);
		
		StartCoroutine (WaitForRequest (www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		if (www.error == null) {
			
			Debug.Log ("www ok!: " + www.text);
		} else {
			
			Debug.Log("www error: " + www.error);
		}
		
	}
	
}