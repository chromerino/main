using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
private int HighScore=0;
private int LastScore=0;
    void Start(){
		HighScore=PlayerPrefs.GetInt("HighScore", 0);
		LastScore=GameControllScript.lastScore;
		if(LastScore>HighScore){
			HighScore=LastScore;
		}
		GameObject.Find("HighScoreScore").GetComponent<UnityEngine.UI.Text>().text=""+HighScore;
		GameObject.Find("LastScoreScore").GetComponent<UnityEngine.UI.Text>().text=""+LastScore;
		
		PlayerPrefs.SetInt("HighScore", HighScore);
	}
   
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