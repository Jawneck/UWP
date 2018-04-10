using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data : MonoBehaviour {

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

}
