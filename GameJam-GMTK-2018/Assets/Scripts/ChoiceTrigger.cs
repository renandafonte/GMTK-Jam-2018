using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTrigger : MonoBehaviour {
	public InkTextObject Object;
	public string ChoiceName;

	public void OnTriggerEnter(){
		Object.ChooseChoice(ChoiceName);
	}

}
