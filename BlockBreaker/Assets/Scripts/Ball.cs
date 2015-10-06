using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddel paddel;
	private bool hasStarted = false;
	private Vector3 paddelToBallVector;
	
	void Start () {
			paddel = GameObject.FindObjectOfType<Paddel>();
			paddelToBallVector = this.transform.position - paddel.transform.position;	
	}
	
	void Update () {
		if(!hasStarted) {
			//lock the ball relative to the paddle.
			this.transform.position = paddel.transform.position + paddelToBallVector;
			//wait for a mouse press to launch.
			if(Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(3f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(1f, 1f),Random.Range(3f, 1.5f));
		rigidbody2D.velocity += tweak;
		if  (hasStarted) {
			audio.Play ();
		}
	}

}
