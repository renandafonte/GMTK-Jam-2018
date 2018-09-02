using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;
  //public AudioMixer audioSom;
    public float volume;
    public FirstPersonController FPC;
    public InkTextObject inkText;
    public AudioSource PauseSound;

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
        InkTextObject obj;
        CanvasInfo c = GameObject.Find("Canvas").GetComponent<CanvasInfo>();
        pauseMenu = c.Pause;
        pauseMenu.SetActive(false);
        FirstPersonController fpc = c.fpc;
        InkTextObject ink = c.inkText;
		switch(GameChapter){
			case 3:
				obj = GameObject.Find("Managers").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[0];
				break;
            case 4:
				obj = GameObject.Find("Cube").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[0];
                break;
            case 5:
				obj = GameObject.Find("Managers").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[1];
                Debug.Log(obj.NextJsons[1]);
                break;
            case 6:
				obj = GameObject.Find("Cube").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[1];
                break;
            case 7:
				obj = GameObject.Find("Cube").GetComponent<InkTextObject>();
				obj.JsonFromInk = obj.NextJsons[2];
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
        PauseSound.Play();
        pauseMenu.SetActive(false);
        FPC.disableFPC(true);
        inkText.disableInk(true);
        Time.timeScale = 1f;

    }

    void Pause()
    {
        //Cursor.visible = true;
        PauseSound.Play();
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
