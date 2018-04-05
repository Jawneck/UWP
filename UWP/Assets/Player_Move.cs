using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public bool facingRight = true;
    private int playerJumpPwr = 400;
    public int playerSpeed = 12;
    private float X;



    // Update is called once per frame.
    void Update() {
        Move();
    }

    void Move() {
        //Movement on the x axis.
        X = Input.GetAxis("Horizontal");

        //Calling the jump method.
        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        
        if(X < 0.0f && facingRight == false){
            Flip();
        }
        else if(X < 0.0f && facingRight == true){
            Flip();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(X * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Method to change the facing direction of player in relation to which way it is moving.
    void Flip(){
        facingRight = !facingRight;
        //Scale of the player changed.
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump(){
        //Accessing the RigidBody2D and adding force in the direction up multiplied by jump power.
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPwr); 
    }

}
