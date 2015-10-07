using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddel paddel;
	private bool hasStarted = false;
	private bool ballLanuched = false;
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
				ballLanuched = true;
				this.rigidbody2D.velocity = new Vector2(3f, 10f);
			}
		}
		// rigidbody2D.velocity.y = Mathf.Clamp (rigidbody2D.velocity.y, 5f, 15f);
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(-0.5f, 0.5f),Random.Range(0.5f, 1f));
		rigidbody2D.velocity += tweak;
		if  (hasStarted) {
			audio.Play ();
		}
	}

}
