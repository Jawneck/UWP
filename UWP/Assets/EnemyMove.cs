using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private int XDirection = 1;
    private int Speed = 2;

	// Update is called once per frame. This method makes the enemy move.
	void Update () {
        //Using a raycast to detect any object that is lying along the path of the ray.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XDirection, 0) * Speed;

        //If the distance between the raycast and whatever it hits is less than 0.7, then flip.
        if(hit.distance < 0.7f){
            Flip();
        }
	}

    //Method to move the enemy left to right.
    void Flip(){
        if(XDirection > 0){
            XDirection = -1;
        }
        else{
            XDirection = 1;
        }
    }
}
