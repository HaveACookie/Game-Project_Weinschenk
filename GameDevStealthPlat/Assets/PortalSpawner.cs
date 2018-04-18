using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour {
    public GameObject portal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.itemConsumed == false)
        {
            portal.SetActive(false);
        }
        if(GameManager.Instance.itemConsumed == true)
        {
            portal.SetActive(true);
        }
	}
}
