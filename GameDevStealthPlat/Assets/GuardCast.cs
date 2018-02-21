using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCast : MonoBehaviour {
	public Transform sightStart, sightEnd;
	public Transform lSideStart, LSideEnd;
	public Transform rSideStart, rSideEnd;

	public bool spotted = false; 
	public bool lSpotted = false; 
	public bool rSpotted = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
	}

	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.cyan);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (lSideStart.position, LSideEnd.position, Color.magenta);
		lSpotted = Physics2D.Linecast (lSideStart.position, LSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (rSideStart.position, rSideEnd.position, Color.yellow);
		rSpotted = Physics2D.Linecast (rSideStart.position, rSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
	}
}
