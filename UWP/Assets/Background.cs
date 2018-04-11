using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float scrollSpeed = -1.5f;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(scrollSpeed, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //If the player stops moving, the background stops scrolling
        if (Player_Move.playerX == 0){
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}
