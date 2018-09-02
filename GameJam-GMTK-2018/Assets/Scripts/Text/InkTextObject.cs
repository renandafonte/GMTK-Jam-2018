﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class InkTextObject : MonoBehaviour {
	public TextAsset JsonFromInk;
	private Story _story;
    List<string> myTagString;
    string tagTemp = "";

	public bool repeat = false;
	private bool hasEnded = false;

	public bool triggeredByObject = false;

	public float TimeBeforePlayerIsAbleToSkipText = 1f;
	private bool isPlayerAbleToSkipText = true;

	public List<TextAsset> NextJsons;
	public GameObject Credits;
	public float MaxTextDuration = 3;

	private bool playerHasSkipped = false;
    public void CallText(){
		//Inicia classe story (veio do plugin do ink)
		Debug.Log(GameManager.instance.GameChapter);
		switch(GameManager.instance.GameChapter){
			case 1:
				_story = new Story(JsonFromInk.text);
				break;
			case 2:
				_story = new Story(JsonFromInk.text);
				break;
			case 3:
				_story = new Story(NextJsons[0].text);
				break;
			case 4:
				_story = new Story(NextJsons[0].text);
				break;
			case 5:
				_story = new Story(NextJsons[1].text);
				break;
			case 6:
				_story = new Story(NextJsons[1].text);
				break;
			case 7:
				_story = new Story(NextJsons[2].text);
				break;
		}
		TextManager.instance.SetTextActive(true); //ativa a caixa de texto
		AdvanceStory();
	}

	public void AdvanceStory(){
		while(_story.canContinue){
			string text = _story.Continue(); //continua história enquanto possível
			TextManager.instance.UpdateText(text); //muda texto
            myTagString = _story.currentTags;

            for (int i = 0; i < myTagString.Count; i++)
            {
				if(myTagString[i].Contains("som")){
					if (tagTemp == "")
						tagTemp = GetTagArgument(myTagString[i]);
					else
					{
						if (tagTemp != GetTagArgument(myTagString[i]))
						{
							tocaPlayStop(tagTemp);
							tagTemp = GetTagArgument(myTagString[i]);
						}
					}
					
					//Debug.Log(myTagString[0]);
					tocaPlay(GetTagArgument(myTagString[i]));
				}

				else if(myTagString[i].Contains("scene")){
					SceneManager.LoadScene(GetTagArgument(myTagString[i]));
				}

				else if(myTagString[i].Contains("zoom")){
					camera.current.gameObject.AddComponent<ZoomCamera>();
				}

				else if(myTagString[i].Contains("lockcam")){
					Debug.Log("TODO LOCKCAM");
				}

				else if(myTagString[i].Contains("showButton")){
					GameManager.instance.ShowButton(true);
				}
            }
        }
	}

	public string GetTagArgument(string tag){
		return tag.Substring(tag.IndexOf('\"') + 1, tag.LastIndexOf('\"') - tag.IndexOf('\"') - 1);
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
		if(triggeredByObject) InteractWithText();
	}

	public void Start(){
		if(!triggeredByObject) InteractWithText();
	}

	public void Update(){
		if(Input.GetMouseButton(0) && !triggeredByObject) InteractWithText();
	}

	public void InteractWithText(){
		if(!isPlayerAbleToSkipText) return;

		switch(TextManager.instance.DialogObj.IsActive()){
			case true:
				int index = SearchChoice("default");
				if(_story.currentChoices.Count > 0 && index != -1){
					_story.ChooseChoiceIndex(index); //se estiver escolhas muda o texto
					AdvanceStory();
				} 
				else{
					TextManager.instance.SetTextActive(false); //senão diálogo acabou
					hasEnded = true;

					if(GameManager.instance.GameChapter == 6 || GameManager.instance.GameChapter == 7){
						gameObject.AddComponent<DestroyWhenNotInCamera>();
						Credits.SetActive(true);
					}
				} 
				break;
			case false:
				if(!hasEnded || repeat) CallText();
				break;
		}

		StartCoroutine(SkipTextCooldown());
		StartCoroutine(AutoSkipText());
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

	IEnumerator SkipTextCooldown(){
		isPlayerAbleToSkipText = false;
		yield return new WaitForSeconds(TimeBeforePlayerIsAbleToSkipText);
		isPlayerAbleToSkipText = true;
	}

	IEnumerator AutoSkipText(){
		yield return new WaitForSeconds(MaxTextDuration);
		if(!playerHasSkipped){
			InteractWithText();
		}
		playerHasSkipped = false;
	}

    public void disableInk(bool x)
    {
        GetComponent<InkTextObject>().enabled = x;
    }
}
