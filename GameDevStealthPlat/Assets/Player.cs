using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {
    public float xSpeed;
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
	public bool MovingRight;
	private Animator anim;
    public GameObject Item;
    public AudioClip Walk;
    public AudioClip PortalOpened;
    public GameObject Portals;
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
        GameManager.Instance.pXSpeed = 10f;
        xSpeed = GameManager.Instance.pXSpeed;
		anim = GetComponent<Animator> ();
        GameManager.Instance.itemConsumed = false;



    }

    // Update is called once per frame
    void Update () {

       // while(isOnGround & (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.LeftArrow)))){
          //  playerAudio.PlayOneShot(Walk);
        //}



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
            isOnGround = false;
			//if (myRigidbody.velocity.y < 0){
			//	myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
			//}
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 8);
            GetComponent<Animator>().SetBool("Jumping", true);


	}

		if (Input.GetKeyDown (KeyCode.V)) {
			Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.red);
			interact = Physics2D.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Item"));
            if (interact)
            {
                GameManager.Instance.itemConsumed = true;
            }
            if(GameManager.Instance.itemConsumed == true)
            {
                Destroy(Item);
            }
		}





}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow)) {
		myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
		facingRight = true;
			MovingRight = true;
            if (MovingRight == true)
            {
                GetComponent<Animator>().SetBool("MovingRight", true);
            }
            mySpriteRenderer2.flipX = false;

		}  else if (Input.GetKey (KeyCode.LeftArrow)) {
		myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
		facingLeft = true; 
			MovingRight = true;
			GetComponent<Animator>().SetBool ("MovingRight", true);
            mySpriteRenderer2.flipX = true;

        }  
		else {
		myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
            MovingRight = false;
            GetComponent<Animator>().SetBool("MovingRight", false);
        }
	}

	void OnCollisionEnter2D(Collision2D CollisionInfo){
		if (CollisionInfo.gameObject.tag == "Floor") {
			isOnGround = true;
			Debug.Log ("HITTING THE FLOOR");
			dustParticle.GetComponent<ParticleSystem> ().enableEmission = true; 
			StartCoroutine (endParticles ());
			playerAudio.PlayOneShot (landing);
            GetComponent<Animator>().SetBool("Jumping", false);
            if (isOnGround == true)
            {
                GetComponent<Animator>().SetBool("Landing", true);
            }
            if(isOnGround == false)
            {
                GetComponent<Animator>().SetBool("Landing", false);
            }
		}
		if (CollisionInfo.gameObject.tag == "Wall") {
			wallChecks = true; 
		}
			
		if (CollisionInfo.gameObject.tag == "Key") {
			DestroyObject (door);
		}
        if (CollisionInfo.gameObject.tag == "Interactable")
        {
            GameManager.Instance.itemConsumed = true;
            if (GameManager.Instance.itemConsumed = true)
            {
                Portals.SetActive(true);
                Destroy(Item);
                playerAudio.PlayOneShot(PortalOpened);
            }
            

        }

		if (CollisionInfo.gameObject.tag == "Winner"){
			SceneManager.LoadScene(3); 
		}

        if (CollisionInfo.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(4); 
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


	void Raycasting () {
		Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.green);


	}









	}

