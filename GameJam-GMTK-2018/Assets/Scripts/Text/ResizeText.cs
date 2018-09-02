using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeText : MonoBehaviour {
	private int initialSize;
	private Text text;

	void Awake(){
		text = GetComponent<Text>();
		initialSize = text.fontSize;
	}

	// Use this for initialization
	void Start () {
		Resize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Resize(){
		text.fontSize = Mathf.FloorToInt(GameManager.instance.TextSize * initialSize * 1.0f/18);
	}
}
