using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {
	public float xSpeed =.4f;
	SpriteRenderer mySpriteRenderer2;
	Rigidbody2D  myRigidbody; 
	public bool isOnGround = true;
	bool facingRight = true;
	bool facingLeft = true;
	public bool wallSliding; 
	public Transform wallCheckPoint;
	public bool wallChecks;
	public LayerMask wallLayerMask;
	public Transform pSightStart, pSightEnd;
	public bool interact = false; 
	float direct;
	public GameObject door;
	public Transform dustParticle;
	Vector2 moveDirection;
	public AudioClip landing;
	public AudioSource playerAudio;
	public bool movingleft;
	public bool movingright;
	private Animator anim;
	//public float fallMultiplier = .1f; 
	//public float lowJumpMultiplier = 2f;
	//public float jumpVelocity; 

	// Use this for initialization
	void Start () {
		mySpriteRenderer2 = GetComponent<SpriteRenderer> ();
		myRigidbody = GetComponent<Rigidbody2D> (); 
		moveDirection = Vector2.zero;
		wallSliding = false;
		wallChecks = false; 
		playerAudio = GetComponent<AudioSource> ();
		dustParticle.GetComponent<ParticleSystem> ().enableEmission = false;
		anim = GetComponent<Animator> ();
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
		if (Input.GetKey (KeyCode.RightArrow)) {
		//	moveDirection += Vector2.right;
			direct = 1 ; 
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//moveDirection += Vector2.left;
			direct = 0 ;
		}

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

		if (isOnGround == false) {
			//wallCheck = Physics2D.OverlapCircle (wallCheckPoint.position, 0.1f, wallLayerMask);

		if (facingRight && Input.GetAxis ("Horizontal") > 0.1f || facingLeft && Input.GetAxis("Horizontal") <0.1f) {
		if (wallChecks) {
			//		HandleWallSliding ();

					wallSliding = true;

					if (wallSliding == true) {
						myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, -0.7f);

						if (Input.GetKeyDown (KeyCode.Space) && wallSliding == true) {

							if (direct == 1) {
							myRigidbody.AddForce (new Vector2 (-50, 3) * 25);
									} 
							if (direct == 0)
								{
									myRigidbody.AddForce (new Vector2 (50, 3) *25);
									}

									}
					}
				}

			}
		}

		if (wallChecks == false || isOnGround) {
			wallSliding = false; 
		}



}

	void FixedUpdate () {
		//myRigidbody.AddForce (moveDirection * xSpeed);
		//float h = Input.GetAxis ("Horizontal");
		//myRigidbody.AddForce ((Vector2.right * xSpeed) * h); 

		if (Input.GetKey (KeyCode.RightArrow)) {
		//transform.position += xSpeed *Time.deltaTime * Vector3.right;
		myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
		facingRight = true;
			movingright = true;
			anim.SetBool ("MovingRight", movingright);

		//mySpriteRenderer2.flipX = false;
		//bulletRight = true; 

		}  else if (Input.GetKey (KeyCode.LeftArrow)) {
		//transform.position -= xSpeed *Time.deltaTime * Vector3.right;
		myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
		//mySpriteRenderer2.flipX = true;
		facingLeft = true; 
			movingleft = true;
			anim.SetBool ("MovingLeft", movingleft);
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
			dustParticle.GetComponent<ParticleSystem> ().enableEmission = true; 
			StartCoroutine (endParticles ());
			playerAudio.PlayOneShot (landing);
		}
		if (CollisionInfo.gameObject.tag == "Wall") {
			wallChecks = true; 
		}
			//if (CollisionInfo.gameObject.tag == "DeathWall") {
			//	SceneManager.LoadScene (0);	
			//}
			//if (CollisionInfo.gameObject.tag == "PowerUp") {
			//	powerupActive = true; 

			//}
		if (CollisionInfo.gameObject.tag == "Key") {
			DestroyObject (door);
		}
		if (CollisionInfo.gameObject.tag == "Winner"){
			//SceneManager.LoadScene(); 
		}

	}

	void OnCollisionExit2D (Collision2D c) {
		if (c.gameObject.tag == "Floor") {
			isOnGround = false;
		}
		if (c.gameObject.tag == "Wall") {
			wallChecks = false; 
		}
	
	}


	IEnumerator endParticles (){

		yield return new WaitForSeconds (.4f);
		dustParticle.GetComponent<ParticleSystem> ().enableEmission = false; 
	}


	//void HandleWallSliding(){
	//myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, -0.7f);
	//	wallSliding = true; 

	//	if (Input.GetButtonDown ("Space")) {
	
	//		if (facingRight) {
				//myRigidbody.AddForce (new Vector2 (-1, 3) * 8);
	//		} 
			//else {
	//			myRigidbody.AddForce (new Vector2 (1, 3) *8 );
//		}

//		}
//	}

	void Raycasting () {
		Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.green);


	}









	}

