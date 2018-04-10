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
    public GameObject highScoreUI;

    // Update is called once per frame
    void Update()
    {
        //Ticks the time down second by second.
        time -= Time.deltaTime;
        //Displaying the time on the timeUI object ingame.
        timeUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)time);
        scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);
        highScoreUI.gameObject.GetComponent<Text>().text = ("High Score: " + gameData.highscore);

        //If you run out of time the level restarts
        if (time < 0.1f){
            SceneManager.LoadScene("prototype");
        }
    }

    //A method to check if the player enters the EndLevel object on trigger.
    void OnTriggerEnter2D(Collider2D trigger){
        //Only call CountScore method if player enters EndLevel object.
        if(trigger.gameObject.name == "EndLevel"){
            CountScore();
        }
        //Add to score each time player enters a Coin.
        if(trigger.gameObject.name == "Coin"){
            score += 100;
            Destroy(trigger.gameObject);//Destroys the coin onTrigger.
        }
    }

    //A method which totals up the player score
    void CountScore(){
        Debug.Log("Current:" + Data.data.HighScore);

        score = score + (int)(time * 10);
        Data.data.HighScore = score + (int)(time * 10);
        Data.data.SaveData();

        Debug.Log("Newly saved data: " + Data.data.HighScore);
    }
}
