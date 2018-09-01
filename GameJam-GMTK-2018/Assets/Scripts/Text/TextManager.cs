using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public static TextManager instance;
	public Text DialogObj;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	public void UpdateText(string text){
		DialogObj.text = text; //atualiza o texto na caixa de texto
	}

	public void SetTextActive(bool status){
		DialogObj.gameObject.SetActive(status);
	}
}
