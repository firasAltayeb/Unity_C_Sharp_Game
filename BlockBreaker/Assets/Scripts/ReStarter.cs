using UnityEngine;
using System.Collections;

public class ReStarter : MonoBehaviour {
	
	private AutoPlay au;
	
	void Start () {
		au = GameObject.FindObjectOfType<AutoPlay>();
		Destroy (au);
	}
	
}
