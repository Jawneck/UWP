using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data : MonoBehaviour {

    //A static class which can be accessed throughout the entire project.
    public static Data data;

    public int highScore;

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
        BinaryFormatter BinForm = new BinaryFormatter();

        //persistentDataPath is the data path that stays around when application is updated
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //Creating game info file.
    }

    //A method which loads all the data.
    public void LoadData(){

    }

}

[Serializable]
class gameData{

    public int highScore;

}