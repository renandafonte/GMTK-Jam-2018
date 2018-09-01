using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkTextObject : MonoBehaviour {
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

	public void ChooseChoice(string name){
		_story.ChooseChoiceIndex(SearchChoice("default"));
		AdvanceStory();
	}

	public int SearchChoice(string name){
		if(_story.currentChoices.Find(choice => choice.text == name) == null) return -1; //se story não tem choices


		return _story.currentChoices.Find(choice => choice.text == name).index;
	}

	public void OnMouseDown(){
		switch(TextManager.instance.DialogObj.IsActive()){
			case true:
				int index = SearchChoice("default");
				Debug.Log(index);
				if(_story.currentChoices.Count > 0 && index != -1){
					_story.ChooseChoiceIndex(index); //se estiver escolhas muda o texto
					AdvanceStory();
				} 
				else TextManager.instance.SetTextActive(false); //senão diálogo acabou
				break;
			case false:
				CallText();
				break;
		}
	}
}
