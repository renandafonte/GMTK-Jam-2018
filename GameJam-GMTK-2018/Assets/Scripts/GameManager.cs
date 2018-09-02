using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;
  //public AudioMixer audioSom;
    public float volume;
    public FirstPersonController FPC;
    public InkTextObject inkText;


	void Awake(){
		DontDestroyOnLoad(gameObject);
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
