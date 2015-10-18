using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public GameObject smoke;
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
		//AudioSource.PlayClipAtPoint (crack, transform.position);
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
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		} 
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			audio.Play ();
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}

}
