using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float xSpeed =.1f;
	SpriteRenderer mySpriteRenderer2;
	Rigidbody2D  myRigidbody; 
	bool isOnGround = true;
	//public float fallMultiplier = .1f; 
	//public float lowJumpMultiplier = 2f;
	//public float jumpVelocity; 

	// Use this for initialization
	void Start () {
		mySpriteRenderer2 = GetComponent<SpriteRenderer> ();
		myRigidbody = GetComponent<Rigidbody2D> (); 
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += xSpeed *Time.deltaTime * Vector3.right;
			myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer2.flipX = false;
			//bulletRight = true; 

		}  else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= xSpeed *Time.deltaTime * Vector3.right;
			myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer2.flipX = true;
			//bulletRight = false;
		}  
		else {
			myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.Space ) && isOnGround){
			Debug.Log ("is on ground: " + isOnGround);
			//if (myRigidbody.velocity.y < 0){
			//	myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
			//}
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 10);
			

	}


}

	void OnCollisionEnter2D(Collision2D CollisionInfo){
		if (CollisionInfo.gameObject.tag == "Floor") {
			isOnGround = true;
			Debug.Log ("HITTING THE FLOOR");
		} 
			//if (CollisionInfo.gameObject.tag == "DeathWall") {
			//	SceneManager.LoadScene (0);	
			//}
			//if (CollisionInfo.gameObject.tag == "PowerUp") {
			//	powerupActive = true; 

			//}

	}

	void OnCollisionExit2D (Collision2D c) {
		if (c.gameObject.tag == "Floor") {
			isOnGround = false;
		}
	}

	}

