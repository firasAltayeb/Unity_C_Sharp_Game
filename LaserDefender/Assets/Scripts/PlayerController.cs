using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject projectile; 
	
	public float speed = 15.0f;
	public float padding = 1f;
	float xmin;
	float xmax;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f; 
	public AudioClip fireSound;
	
	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			//The "Fire" is referring to the Fire method.
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
	
		if (Input.GetKey(KeyCode.LeftArrow)) {
				transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
				transform.position += Vector3.right * speed * Time.deltaTime;
		}
		// restrict the player to the game space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y,transform.position.z);
	}
	
	void Fire(){
		//Vector3 startPostition =  transform.position + new Vector3(0, 1, 0);	 
		GameObject laser = Instantiate(projectile,  transform.position, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0, projectileSpeed);	
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if(projectile){
			Debug.Log("Player is hit by a projectile");
			health -= projectile.getDamage();
			projectile.Hit();
			if(health <= 0){
				Die();
			}
		}
	}
	
	void Die(){
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Win Screen");
		Destroy(gameObject);
		Debug.Log("Player is destroyed by a projectile");
	}
	
	
}
