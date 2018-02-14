﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
 
[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

	// Use this for initialization
	public override void OnInspectorGUI () {

		DrawDefaultInspector ();



		CameraFollow cf = (CameraFollow)target;
		if (GUILayout.Button ("Set Min Cam Pos")) {
		
			cf.SetMinCamPosition ();
		
		}
		if (GUILayout.Button ("Set Max Cam Pos")) {

			cf.SetMaxCamPosition ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}