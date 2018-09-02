using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int GameChapter = 0;
    public GameObject pauseMenu;

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
