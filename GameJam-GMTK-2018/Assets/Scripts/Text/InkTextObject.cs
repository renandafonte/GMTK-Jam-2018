using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkTextObject : MonoBehaviour {
	public TextAsset JsonFromInk;
	private Story _story;
    List<string> myTagString;
    private AudioSource audioVoice;

    private void Start()
    {
        
    }

    private void Update()
    {
        /*string myText = _story.Continue();
        List<string> myTagString = _story.currentTags;
        string speakerAudioLine = myTagString[0];

        if (Input.GetKeyDown("space"))
            Debug.Log(speakerAudioLine);*/
    }

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
            Debug.Log(_story.currentTags);
            Debug.Log(myTagString[0]);

        }
	}

	public void ChooseChoice(int index){
		_story.ChooseChoiceIndex(index);
		AdvanceStory();
	}

	public void OnMouseDown(){
		switch(TextManager.instance.DialogObj.IsActive()){
			case true:
				AdvanceStory();
				break;
			case false:
				CallText();
				break;
		}
	}

    public void tocaPlay(string audioNom)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
