using UnityEngine;
using System.Collections;

//@Author Jordi Prummel

public class LoadScene : MonoBehaviour {
	public string sceneName;

	public void ChangeLevel()
	{
		Application.LoadLevel (sceneName);
	}
}
