using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;

	public static GameManager instance;

	void Awake(){
		DontDestroyOnLoad(gameObject);

		//Se já houver um gamemanager, destrói esse. 
		//isso deixa a gente por em todas as cenas, sem se preocupar com duplicados
		if(instance == null) instance = this;
		else Destroy(gameObject);
		
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		GameChapter++;

		switch(GameChapter){
			case 2:
				var obj = GameObject.Find("Managers").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[0];
				break;
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
                Pause();
            else
                Resume();
        }

    }

    private void Start()
    {
        pauseMenu = GameObject.Find("pauseMenu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }

}
