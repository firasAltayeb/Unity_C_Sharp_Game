using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHits;
	
	void Start () {
		timesHits = 0;
	}
	
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		timesHits++;
	}
	
}
