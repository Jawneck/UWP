using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume (float volume){

        //Sets the master volume via the volume slider.
        audioMixer.SetFloat("Volume", volume);
    }
}
