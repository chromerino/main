using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

   
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
	public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }  
	public void Quit()
    {
        Application.Quit();
    }

}