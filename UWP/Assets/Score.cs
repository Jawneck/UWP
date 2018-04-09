using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    //Constants and Variables
    public float time = 100;
    public int score = 0;

	// Update is called once per frame
	void Update () {
        //Ticks the time down second by second
        time -= Time.deltaTime;

        //If you run out of time the level restarts
        if(time < 0.1f){
            SceneManager.LoadScene("prototype");
        }
	}
}
