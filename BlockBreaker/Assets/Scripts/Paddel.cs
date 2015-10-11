using UnityEngine;
using System.Collections;

public class Paddel : MonoBehaviour {
	
	public bool autoPlay = false;
	private Ball ball;
	private AutoPlay au;
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		au = GameObject.FindObjectOfType<AutoPlay>();
	}
	
	void Update () {
		if(au.autoPlay || autoPlay) {
			AutoPlay();
		} else {
			MoveWithMouse();
			//FixedUpdate();
		}
	}
	
	/*void FixedUpdate(){
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,this.transform.position.z);
		float accelerometerPos = Input.acceleration.x * 30;
		paddlePos.x = Mathf.Clamp(accelerometerPos, 0.5f, 15.5f);
		print (accelerometerPos);
		this.transform.position = paddlePos;
	}*/

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
