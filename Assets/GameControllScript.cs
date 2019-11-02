using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllScript : MonoBehaviour
{
public static int lastScore=0;
private double timeStamp=0;
private int mult=1;
private int Score=0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed=true){
	mult=3;
	}else{
		mult=1;
	}

	if (timeStamp <= Time.time)
     {

	   Score+=(1*mult);
       timeStamp+=0.01;

     }
	 GameObject.Find("ScoreCountText").GetComponent<UnityEngine.UI.Text>().text = ""+Score;
        
    }

	public void addKill(){
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed=true){
	mult=3;
	}else{
		mult=1;
	}
	Score+=(500*mult);
	}

	public void addItem(){
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed=true){
	mult=3;
	}else{
		mult=1;
	}
	Score+=(150*mult);
	}

	public void end(){
		lastScore=Score;
	}

}
