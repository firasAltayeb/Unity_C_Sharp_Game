using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update(){
		float	probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability){
			Fire ();
		}		
	}
	
	void Fire(){
		//Vector3 startPostition =  transform.position + new Vector3(0, -1, 0);	 
		GameObject laser = Instantiate(projectile, transform.position , Quaternion.identity) as GameObject ;
		laser.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	

	void OnTriggerEnter2D(Collider2D collider){
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if(projectile){
			Debug.Log("Enemy is hit by a projectile");
			health -= projectile.getDamage();
			projectile.Hit();
			if(health <= 0){
				Die();
			}
		}
	}
	
	void Die(){
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Debug.Log("Enemy is destroyed by a projectile");
	}
	
}
