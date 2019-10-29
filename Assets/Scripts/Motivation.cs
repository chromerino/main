using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motivation : MonoBehaviour
{

string[] Motivations=new string [6];

private double timeStamp=0;
    // Start is called before the first frame update
    void Start()
    {
	
	   GetComponent<UnityEngine.UI.Text>().text = "";
	          Motivations[0]="Good Job!";
       Motivations[1]="Keep going!";
       Motivations[2]="Nice Work!";
	   Motivations[3]="Nice Killstreak!";
	   Motivations[4]="YOU ARE AMAZING!!!";
	   Motivations[5]="WOOOOOOOOOOOOW!";
    }

    public void motivate(){
	
	int randPos = Random.Range(0, Motivations.Length);
	GetComponent<UnityEngine.UI.Text>().text = Motivations[randPos];
	timeStamp = Time.time + 2;
	}
	void Update(){
		if (timeStamp <= Time.time)
     {
     GetComponent<UnityEngine.UI.Text>().text = "";
     
     }
	}
}


