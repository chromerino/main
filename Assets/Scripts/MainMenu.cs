﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
	public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
	public void Options()
    {
        SceneManager.LoadScene("Options");
    }
	public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
	public void Exit()
    {
        Application.Quit();
    }

}