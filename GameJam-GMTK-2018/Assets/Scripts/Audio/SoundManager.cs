using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
	public float BGMVolume = 1f, SFXVolume = 1f, ambientVolume = 1f;
	public static SoundManager instance;

	private AudioList audioList;

	// Use this for initialization
	void Awake(){
		instance = this;
		UpdateAudioList();
	}

	void Start () {
		DontDestroyOnLoad(this);
	}

	public void OnVolumeChange(Slider slider){
		BGMVolume = slider.value;
		SFXVolume = slider.value;
		ambientVolume = slider.value;

		UpdateAudios();
	}
	public void OnBGMVolumeChange(Slider slider){
		BGMVolume = slider.value;
		UpdateAudios();
	}
	public void OnSFXVolumeChange(Slider slider){
		SFXVolume = slider.value;
		UpdateAudios();
	}
	public void OnAmbientVolumeChange(Slider slider){
		ambientVolume = slider.value;
		UpdateAudios();
	}

    public void UpdateAudioList()
    {
        audioList = GameObject.Find("Audios").GetComponent<AudioList>();
		UpdateAudios();
    }

	public void UpdateAudios(){
		foreach(AudioList.AudioInfo audio in audioList.audioList){
			float volume = 1;

			switch(audio.type){
				case AudioList.AudioType.BGM:
					volume = BGMVolume;
					break;
				case AudioList.AudioType.SFX:
					volume = SFXVolume;
					break;
				case AudioList.AudioType.Ambient:
					volume = ambientVolume;
					break;
			}

			audio.source.volume = volume;
		}
	}
}
