using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	private int levelNumber = 1;
	
	public void LoadLevel(string name){	
		Debug.Log("level load requested for: "+name);
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel() {
			/*if (levelNumber == 2) {
					print ("level 2 if ");
					levelNumber++;
					Application.LoadLevel("Level_02");
			}
			else if (levelNumber == 3) {
					print ("level 3 if");
					levelNumber++;
					Application.LoadLevel("Level_03");
			}
			else{
				Application.LoadLevel("WinScreen");
			}*/
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			//print ("level number will increase");
			//levelNumber++;
			LoadNextLevel();
		}
	}
	
}
