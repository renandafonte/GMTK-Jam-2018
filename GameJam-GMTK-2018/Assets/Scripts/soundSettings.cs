using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class soundSettings : MonoBehaviour {

    public Slider volume;
    public AudioMixer audioMixer;
    public GameObject som;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
