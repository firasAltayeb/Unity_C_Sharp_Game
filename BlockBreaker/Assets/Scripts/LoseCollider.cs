using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
		
		public LevelManager levelManager;
		void OnTriggerEnter2D (Collider2D trigger) {
			print ("Trigger");
			levelManager.LoadLevel("winScreen");
		}
		
		void OnCollisionEnter2D (Collision2D collision) {
			print ("Collision");
		}

}
