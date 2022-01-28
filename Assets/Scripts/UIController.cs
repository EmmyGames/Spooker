﻿using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image blackOverlay;
    public Image backButton;
    public Image resumeButton;
    public Image restartButton;
    public Image helpButton;
    public Image quitButton;
    
    public Image helpScreen;
    public Image loseScreen;
    public Image winScreen;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        blackOverlay.enabled = false;
        backButton.enabled = false;
        resumeButton.enabled = false;
        restartButton.enabled = false;
        helpButton.enabled = false;
        quitButton.enabled = false;
        helpScreen.enabled = false;
        loseScreen.enabled = false;
        winScreen.enabled = false;
    }

    void Update()
    {
        //ESCAPE KEY
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }  
    }

    //PAUSE & RESUME
    public void Pause()
    {
        if(Time.timeScale > 0f)
        {
            Time.timeScale = 0;
            blackOverlay.enabled = true;
            resumeButton.enabled = true;
            helpButton.enabled = true;
            quitButton.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            blackOverlay.enabled = false;
            resumeButton.enabled = false;
            helpButton.enabled = false;
            quitButton.enabled = false;
            helpScreen.enabled = false;
        }
    }

    //HELP
    public void Help()
    {
        resumeButton.enabled = false;
        helpButton.enabled = false;
        quitButton.enabled = false;
        backButton.enabled = true;
        helpScreen.enabled = true;
    }

    //QUIT
    public void Quit()
    {
        Application.Quit();
    }

    //BACK
    public void Back()
    {
        resumeButton.enabled = true;
        helpButton.enabled = true;
        quitButton.enabled = true;
        backButton.enabled = false;
        helpScreen.enabled = false;
    }

    public void Win()
    {
        Time.timeScale = 0;
        winScreen.enabled = true;
        restartButton.enabled = true;
        quitButton.enabled = true;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        loseScreen.enabled = true;
        restartButton.enabled = true;
        quitButton.enabled = true;
    }

    public void Restart()
    {
        
        /*
        
        CountdownTimer.ResetTimer();
        winScreen.enabled = false;
        loseScreen.enabled = false;
        restartButton.enabled = false;
        Pause();
        */
        GameState.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
