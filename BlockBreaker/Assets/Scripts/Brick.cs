using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] hitSprites;
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
		if (timesHits >= maxHits) {
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		} 
	}
	
	void LoadSprites () {
		int spriteIndex = timesHits - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	
	//TODO Remove this method once we can actually win!
	void SimulateWin(){
		levelManger.LoadNextLevel();
	}
	
}
