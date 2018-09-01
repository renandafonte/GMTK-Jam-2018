using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ShowInkText : MonoBehaviour {
	public TextAsset JsonFromInk;
	private Story _story;

	public void CallText(){
		//Inicia classe story (veio do plugin do ink)
		_story = new Story(JsonFromInk.text);
		TextManager.instance.SetTextActive(true); //ativa a caixa de texto
		AdvanceStory();
	}

	public void AdvanceStory(){
		while(_story.canContinue){
			string text = _story.Continue(); //continua história enquanto possível
			TextManager.instance.UpdateText(text); //muda texto
		}
	}

	public void OnMouseDown(){
		CallText();
	}
}
