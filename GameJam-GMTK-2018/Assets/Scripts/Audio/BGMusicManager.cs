using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour {
	public static BGMusicManager instance;
	void Awake(){
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
