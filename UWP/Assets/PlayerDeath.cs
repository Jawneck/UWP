using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public bool Death;
    public int Health;

	// Use this for initialization
	void Start (){
        Death = false;
	}
	
	// Update is called once per frame
	void Update (){
        if (gameObject.transform.position.y < -10){
            Death = true;
        }
            if(Death == true){
            StartCoroutine("Die");
            }
	}

    //Upon "Death" the prototype file is loaded, effectively restarting the game.
    IEnumerator Die(){
        SceneManager.LoadScene("prototype");
        yield return null;
    }
}
