using UnityEngine;
using System.Collections;

public class LevelManger : MonoBehaviour {

	public void LoadLevel(string name){	
		Debug.Log("level load requested for: "+name);
		Application.LoadLevel(name);
	}
	
}
