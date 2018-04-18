using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    
    // Use this for initialization
    void Start() {
        
    }

 

    private void OnCollisionEnter2D(Collision2D CollisionInfo)
    {
        if( CollisionInfo.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }

}
