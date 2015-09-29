using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHits;
	private LevelManager levelManger;
	
	void Start () {
		timesHits = 0;
		levelManger = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		timesHits++;
		SimulateWin();
	}
	
	//TODO Remove this method once we can actually win!
	void SimulateWin(){
		levelManger.LoadNextLevel();
	}
	
}
