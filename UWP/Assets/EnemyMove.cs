using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private int X = 1;
    private int Speed = 2;

	// Update is called once per frame. This method makes the enemy move.
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(X, 0) * Speed;
	}
}
