using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
<<<<<<< HEAD
using UnityStandardAssets.Characters.FirstPerson;
=======
using UnityEngine.SceneManagement;
>>>>>>> ff73196a846c57343fdf5458be0c43429e676c6d

public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;
  //public AudioMixer audioSom;
    public float volume;
    public FirstPersonController FPC;
    public InkTextObject inkText;


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
     //pauseMenu = GameObject.Find("Pause");
    }

    public void Resume()
    {
        Debug.Log("resume");
        pauseMenu.SetActive(false);
        FPC.disableFPC(true);
        inkText.disableInk(true);
        Time.timeScale = 1f;

    }

    void Pause()
    {
      //Cursor.visible = true;
        pauseMenu.SetActive(true);
        FPC.disableFPC(false);
        inkText.disableInk(false);
        Time.timeScale = 0f;

    }

    public void sceneQuit()
    {
        Application.Quit();
    }

}
