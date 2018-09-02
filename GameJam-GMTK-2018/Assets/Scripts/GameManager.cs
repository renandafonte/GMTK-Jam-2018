﻿using System.Collections;
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
    public InkTextObject inkText;

    Vector3 pos = new Vector3(534.574f, 1.195339f, 617.7256f);
    Vector3 rot = new Vector3(0, -93.3f, 0);
    Vector3 posCam = new Vector3(0.001886987f, 0.8f, 0f);
    Vector3 rotCam = new Vector3(20.5f, 0, 0);
    public GameObject player;
    public GameObject playerCamera;

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
        if(SoundManager.instance != null) SoundManager.instance.UpdateAudioList();

		GameChapter++;
        InkTextObject obj;
        CanvasInfo c = GameObject.Find("Canvas").GetComponent<CanvasInfo>();
        pauseMenu = c.Pause;
        pauseMenu.SetActive(false);
        FirstPersonController fpc = c.fpc;
        InkTextObject ink = c.inkText;

        if(GameChapter > 1) ShowButton(false);
	}

    public void ShowButton(bool status){
        Transform nextButton = GameObject.Find("Canvas").transform.Find("Next");
        if(nextButton != null){
            nextButton.gameObject.SetActive(status);
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

        //jogo está pausado
        if(Time.timeScale == 0f){
            if(Input.GetKeyDown(KeyCode.Q)){
                sceneQuit();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Transport");
            instantTranport(pos);
        }
    }

    private void Start()
    {
     //pauseMenu = GameObject.Find("Pause");
    }

    public void Resume()
    {
        Debug.Log("resume");
        GameObject.Find("Pause Menu Audio").GetComponent<AudioSource>().Play();
        pauseMenu.SetActive(false);
        FirstPersonController fpc = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        fpc.disableFPC(true);
        if(inkText != null) inkText.disableInk(true);
        Time.timeScale = 1f;

    }

    void Pause()
    {
        //Cursor.visible = true;
        GameObject.Find("Pause Menu Audio").GetComponent<AudioSource>().Play();
        pauseMenu.SetActive(true);
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().disableFPC(false);
        if(inkText != null) inkText.disableInk(false);
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

    public void instantTranport(Vector3 pos)
    {
        Debug.Log("PLayer" + player);
        Debug.Log("pos" + pos);
        Debug.Log(player.transform.position);
        player.transform.position = pos;
        player.transform.rotation = Quaternion.Euler(rot);
        playerCamera.transform.position = posCam;
        playerCamera.transform.rotation = Quaternion.Euler(rotCam);
        Debug.Log(player.transform.position);
        //jog.transform.rotation = -90f;
    }
}
