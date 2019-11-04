using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    // Start is called before the first frame update
	public int Score;
	int Kills;
    
	void Start(){
		Kills=0;
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<UnityEngine.UI.Text>().text = Score+"";
    }
	public void increment(){
	Kills++;
	if(Kills%10==0){
	GameObject.Find("MotivationalText").GetComponent<Motivation>().motivate();
	GameObject.Find("Player").GetComponent<PlayerMobility>().Hp++;
	}
	Score++; 
	}
}   
