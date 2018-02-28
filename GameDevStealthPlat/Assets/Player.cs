using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float xSpeed =.4f;
	SpriteRenderer mySpriteRenderer2;
	Rigidbody2D  myRigidbody; 
	bool isOnGround = true;
	bool facingRight = true;
	bool facingLeft = true;
	public bool wallSliding; 
	public Transform wallCheckPoint;
	public bool wallCheck;
	public LayerMask wallLayerMask;
	public Transform pSightStart, pSightEnd;
	public bool interact = false; 

	Vector2 moveDirection;
	//public float fallMultiplier = .1f; 
	//public float lowJumpMultiplier = 2f;
	//public float jumpVelocity; 

	// Use this for initialization
	void Start () {
		mySpriteRenderer2 = GetComponent<SpriteRenderer> ();
		myRigidbody = GetComponent<Rigidbody2D> (); 
		moveDirection = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {





		//if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += xSpeed *Time.deltaTime * Vector3.right;
			//myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);

			//mySpriteRenderer2.flipX = false;
			//bulletRight = true; 

		//} // else if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position -= xSpeed *Time.deltaTime * Vector3.right;
			//myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
		//	mySpriteRenderer2.flipX = true;
			//bulletRight = false;
		//}  
		//else {
			//myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
		//}
		//moveDirection = Vector2.zero;
	//	if (Input.GetKey (KeyCode.RightArrow)) {
		//	moveDirection += Vector2.right;
		//}

		//if (Input.GetKey (KeyCode.LeftArrow)) {
		//	moveDirection += Vector2.left;
	//	}

		if (Input.GetKeyDown (KeyCode.Space ) && isOnGround ){
			Debug.Log ("is on ground: " + isOnGround);
			//if (myRigidbody.velocity.y < 0){
			//	myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
			//}
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 8);


	}

		if (Input.GetKeyDown (KeyCode.V)) {
			Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.red);
			interact = Physics2D.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Player"));

		}

		//if (isOnGround = false) {
		//	wallCheck = Physics2D.OverlapCircle (wallCheckPoint.position, 0.1f, wallLayerMask);
			//if (facingRight && Input.GetAxis ("Horizontal") > 0.1f || facingLeft && Input.GetAxis("Horizontal") <0.1f) {

			//	if (wallCheck) {
			//		HandleWallSliding ();
			//	}

			//}
		//}

		//if (wallCheck == false || isOnGround) {
		//	wallSliding = false; 
		//}



}

	void FixedUpdate () {
		//myRigidbody.AddForce (moveDirection * xSpeed);
		//float h = Input.GetAxis ("Horizontal");
		//myRigidbody.AddForce ((Vector2.right * xSpeed) * h); 

		if (Input.GetKey (KeyCode.RightArrow)) {
		transform.position += xSpeed *Time.deltaTime * Vector3.right;
		myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
		facingRight = true;

		mySpriteRenderer2.flipX = false;
		//bulletRight = true; 

		}  else if (Input.GetKey (KeyCode.LeftArrow)) {
		transform.position -= xSpeed *Time.deltaTime * Vector3.right;
		myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
		mySpriteRenderer2.flipX = true;
		facingLeft = true; 
		//bulletRight = false;
		}  
		else {
		myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
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


	void HandleWallSliding(){
		myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, -0.7f);
		wallSliding = true; 

		if (Input.GetButtonDown ("Space")) {

			if (facingRight) {
				myRigidbody.AddForce (new Vector2 (-1, 3) * 8);
			} 
			else {
				myRigidbody.AddForce (new Vector2 (1, 3) *8 );
			}

		}
	}

	void Raycasting () {
		Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.green);


	}









	}

