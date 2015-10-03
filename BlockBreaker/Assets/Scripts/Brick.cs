using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

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
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
		HandleHits();
		}
	}
	
	void HandleHits() {
		timesHits++;
		int maxHits = hitSprites.Length +1;
		if (timesHits >= maxHits) {
			Destroy(gameObject);
		} else {
			LoadSprites();
		} 
	}
	
	void LoadSprites () {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex]) {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	
	//TODO Remove this method once we can actually win!
	void SimulateWin(){
		levelManger.LoadNextLevel();
	}
	
}
