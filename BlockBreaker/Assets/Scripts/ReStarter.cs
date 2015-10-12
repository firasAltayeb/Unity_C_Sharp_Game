using UnityEngine;
using System.Collections;

public class ReStarter : MonoBehaviour {
	
	private AutoPlay ap2;
	
	void awake () {
		ap2 = GameObject.FindObjectOfType<AutoPlay>();
		Destroy (ap2.gameObject);
	}
	
}
