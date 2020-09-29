using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

	public Sprite backGroundOne;
	public Sprite backGroundTwo;
	public Sprite backGroundThree;
	public Sprite backGroundFour;
	
		
	public void loadBackGround(int backGroundNumber) {
		if(backGroundNumber == 1){
			this.GetComponent<SpriteRenderer>().sprite = backGroundOne;
		}  else if(backGroundNumber == 2){
			this.GetComponent<SpriteRenderer>().sprite = backGroundTwo;
		}  else if(backGroundNumber == 3) {
			this.GetComponent<SpriteRenderer>().sprite = backGroundThree;
		}  else {
			this.GetComponent<SpriteRenderer>().sprite = backGroundFour;
		}	
	}
	
}