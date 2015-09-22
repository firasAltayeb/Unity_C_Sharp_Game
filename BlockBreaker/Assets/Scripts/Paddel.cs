using UnityEngine;
using System.Collections;

public class Paddel : MonoBehaviour {
	
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,-0.5f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
		
	}
}
