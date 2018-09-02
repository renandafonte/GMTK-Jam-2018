using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToScene : MonoBehaviour {
	public int secondsBeforeChangeScene;
	public string GoToScene;

	// Use this for initialization
	void Start () {
		StartCoroutine(CountdownBeforeChangeScene());
	}
	
	public IEnumerator CountdownBeforeChangeScene(){
		yield return new WaitForSeconds(secondsBeforeChangeScene);
		SceneManager.LoadScene(GoToScene);
	}
}
