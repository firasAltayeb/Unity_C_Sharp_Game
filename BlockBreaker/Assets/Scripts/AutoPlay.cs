using UnityEngine;
using System.Collections;

public class AutoPlay : MonoBehaviour {
	
	static AutoPlay instance = null;
	public bool autoPlay = false;

	public void autoMode() {
		autoPlay = true;
		print (autoPlay == true);
	}
	
	void Awake () {
		if(instance != null) {
			Destroy (gameObject);
			//	print (" GameObject destroyed"); 	
		}else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}	
	}
}
