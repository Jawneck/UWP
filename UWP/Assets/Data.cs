using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data : MonoBehaviour {

    //A static class which can be accessed throughout the entire project.
    public static Data data;

    public int HighScore;

    //A method inside Awake. Awake happens before Start.
    void Awake(){
        if(data == null){//if there is no object called data, then dont destroy this game object.
            DontDestroyOnLoad(gameObject);
            data = this;//as this will now be the data object.
        }
        else if(data != this){//if there is a data object already.
            Destroy(gameObject);//Destroy it.
        }
    }

    //A method which saves all the data.
    public void SaveData(){
        //Creating a binary formatter.
        BinaryFormatter BinForm = new BinaryFormatter();

        //persistentDataPath is the data path that stays around when application is updated
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //Creating game info file.

        //Creating a container for the data.
        gameData gameData = new gameData();
        gameData.highscore = HighScore;//Getting HighScore from Data and putting it into the highscore in gameData class.

        //Serializes to a binary file.
        BinForm.Serialize(file, gameData);

        file.Close();
    }

    //A method which loads all the data.
    public void LoadData(){

    }

}

[Serializable]
class gameData{

    public int highscore;

}