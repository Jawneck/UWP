using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //Constants and Variables
    public float time = 100;
    public int score = 0;
    public GameObject timeUI;
    public GameObject scoreUI;

    // Update is called once per frame
    void Update()
    {
        //Ticks the time down second by second.
        time -= Time.deltaTime;
        //Displaying the time on the timeUI object ingame.
        timeUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)time);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);

        //If you run out of time the level restarts
        if (time < 0.1f){
            SceneManager.LoadScene("prototype");
        }
    }

    //A method to check if the player enters the EndLevel object on trigger.
    void OnTriggerEnter2D(Collider2D col)
    {
        CountScore();
    }

    //A method which totals up the player score
    void CountScore(){
        score = score + (int)(time * 10);
    }
}
