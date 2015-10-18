using UnityEngine;
using System.Collections;


public class Paddel : MonoBehaviour {
	
	public bool autoPlay = false;
	public bool apAutoPlay = false;
	private Ball ball;
	private AutoPlay ap;
	public float minX = 1.8f;
	public float maxX = 14.2f; 
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		try {
		ap = GameObject.FindObjectOfType<AutoPlay>();
			apAutoPlay = ap.autoPlay; 
			} 
		catch (System.NullReferenceException e){}
	}
	
	void Update () {
		if(apAutoPlay || autoPlay) {
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
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
