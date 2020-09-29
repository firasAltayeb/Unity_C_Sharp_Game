using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f; 
	public float spawnDelay = 0.5f;
	
	private bool movingRight = false;
	private float xmax;
	private float xmin;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBondary = Camera.main.ViewportToWorldPoint( new Vector3(0,0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint( new Vector3(1,0, distanceToCamera));
		xmax = rightBoundary.x;
		xmin = leftBondary.x;
		SpwanUntilFull();
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
				transform.position +=  Vector3.right * speed * Time.deltaTime;
		} 	
		else{
				transform.position += Vector3.left * speed * Time.deltaTime;
		}	
		
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		
		if(leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax){
			movingRight = !movingRight;
		}
		
		if(AllMembersDead()){
			//Debug.Log("Empty formation");
			SpwanUntilFull();
		}
	}
	
	/*void SpawnEnemies(){
		foreach( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}		
	}*/
	
	void SpwanUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		
		if(NextFreePosition()){
				/*The "SpawnUntilFull" string is calling SpawnUntilFull() method
				and spwanDelay will be the argument sent to it */
			Invoke ("SpwanUntilFull", spawnDelay);
		} 
	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}	
		}
		return null;
	}

	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}	
		}
		return true;
	}
	
}