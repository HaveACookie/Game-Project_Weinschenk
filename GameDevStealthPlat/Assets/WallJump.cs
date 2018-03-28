using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {
	public float distance = 1f;
	Player movement; 

	// Use this for initialization
	void Start () {
		movement = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance); 
	
		if (Input.GetKeyDown (KeyCode.Space) && !!movement.isOnGround) {

		}
	
	}	


	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red; 

	//	Gizmos.DrawLine (transform.position, Vector3.right * transform.localScale.x, distance);

	}

}
