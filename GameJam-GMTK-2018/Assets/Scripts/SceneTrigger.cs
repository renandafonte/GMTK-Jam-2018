using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour {
	public string NextScene;

	// Use this for initialization
	void OnTriggerEnter()
	{
		SceneManager.LoadScene(NextScene);
	}
}
