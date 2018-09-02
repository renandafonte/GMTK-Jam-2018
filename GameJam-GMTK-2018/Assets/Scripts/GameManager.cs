using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
  //public AudioMixer audioSom;
    public float volume;
    public FirstPersonController FPC;
    public InkTextObject inkText;
    public AudioSource PauseSound;

    public int TextSize = 18;

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

        GameObject nextButton = GameObject.Find("Next");
        if(GameChapter > 1 && nextButton != null){
            nextButton.SetActive(false);
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

    public void Settings(){
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void BackToMenu(){
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void sceneQuit()
    {
        Application.Quit();
    }

}
