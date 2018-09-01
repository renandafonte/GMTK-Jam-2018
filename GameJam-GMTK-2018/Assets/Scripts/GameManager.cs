using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int GameChapter = 0;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}
