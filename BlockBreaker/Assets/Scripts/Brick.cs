using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private int timesHits;
	private LevelManager levelManger;
	private bool isBreakable ;
	
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHits = 0;
		levelManger = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(isBreakable) {
		HandleHits();
		}
	}
	
	void HandleHits() {
		timesHits++;
		int maxHits = hitSprites.Length +1;
		if (timesHits >= maxHits) {
			breakableCount--;
			levelManger.BrickDestroyed();
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
