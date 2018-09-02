using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkTextObject : MonoBehaviour {
	public TextAsset JsonFromInk;
	private Story _story;
    List<string> myTagString;
    string tagTemp = "";

	public bool repeat = false;
	private bool hasEnded = false;

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
            myTagString = _story.currentTags;

            if (myTagString.Count > 0)
            {
                if (tagTemp == "")
                    tagTemp = myTagString[0];
                else
                {
                    if (tagTemp != myTagString[0])
                    {
                        tocaPlayStop(tagTemp);
                        tagTemp = myTagString[0];
                    }
                }
                
                //Debug.Log(myTagString[0]);
                tocaPlay(myTagString[0]);
            }
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
				else{
					TextManager.instance.SetTextActive(false); //senão diálogo acabou
					hasEnded = true;
				} 
				break;
			case false:
				if(!hasEnded || repeat) CallText();
				break;
		}
	}

    public void tocaPlay(string audioNom)
    {
        //Debug.Log(audioNom);
        AudioSource audio = GameObject.Find(audioNom).GetComponent<AudioSource>();
        //Debug.Log(audio);
        audio.Play();
    }

    public void tocaPlayStop(string audioNom)
    {
        AudioSource audio = GameObject.Find(audioNom).GetComponent<AudioSource>();
        audio.Stop();
    }
}
