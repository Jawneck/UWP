﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    private bool facingRight = false;
    private int playerJumpPwr = 400;
    private int playerSpeed = 12;
    public static float playerX;
    private bool touchingGround;
    private float playerBottomRayDistance = 0.2f;

    // Update is called once per frame.
    void Update() {
        Move();
        PlayerRay();
    }

    void Move() {
        //Movement on the x axis.
        playerX = Input.GetAxis("Horizontal");

        //Calling the jump method. Stopping the player from jumping more than once.
        if(Input.GetButtonDown("Jump") && touchingGround == true){
            Jump();
        }
        //Flipping the player when it is moving left or right.
        if(playerX < 0.0f && facingRight == false){
            Flip();
        }
        else if(playerX > 0.0f && facingRight == true){
            Flip();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //Animations
        //If player is moving on the x-plane, then running is true. Otherwise false. 
        if(playerX != 0){
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else{
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
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
        touchingGround = false;
    }

    //A method to check if the player is touching the ground.
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            touchingGround = true;
        }
    }

    void PlayerRay(){
        //Using a raycast to detect any object that is underneath the player.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        //Bouncing the player off an enemy.
        if (hit.distance < playerBottomRayDistance && hit.collider.tag == "Enemy"){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
            Destroy(hit.collider.gameObject);
        }
    }
}
