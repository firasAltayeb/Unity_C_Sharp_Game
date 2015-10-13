using UnityEngine;
using System.Collections;

public class ReStarter : MonoBehaviour {
	
	private AutoPlay ap;
	
	void Start () {
		ap = GameObject.FindObjectOfType<AutoPlay>();
		Destroy (ap.gameObject);
	}
	
}
