﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Animator transition;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
     

    }


    private TimeSpan timePlaying;
    void Pause()
    {

       

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        TimerController.instance.EndTimer();
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("MainMenu"));
        

    } 

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
       
    }

    

}
