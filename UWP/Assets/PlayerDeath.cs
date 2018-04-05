using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public bool Death;
    public int Health;

	// Use this for initialization
	void Start (){
        Death = true;
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

    IEnumerator Die(){
        yield return new WaitForSeconds(2);
    }
}
