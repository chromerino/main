using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject[] Hearts;
	public GameObject[] UIHighlights;
	public GameObject player;
	public Sprite HealthSprite;
	public Sprite DeadSprite;
	private SpriteRenderer sr;
    public int MaxHealth;
	public int CurrentHealth;

	void Start(){
	for(int i=0; i<UIHighlights.Length; i++){
		UIHighlights[i].GetComponent<Renderer>().enabled = false;
	}
	if(MaxHealth<=3){
	UIHighlights[0].GetComponent<Renderer>().enabled = true;
	}
	else if(MaxHealth==4){
	UIHighlights[1].GetComponent<Renderer>().enabled = true;
	}
	else if(MaxHealth==5){
	UIHighlights[2].GetComponent<Renderer>().enabled = true;
	}
	else if(MaxHealth==4){
	UIHighlights[3].GetComponent<Renderer>().enabled = true;
	}
	if(6<MaxHealth){
	MaxHealth=6;
    }
	CurrentHealth=MaxHealth;
	for(int i=MaxHealth; i<6; i++){
	Hearts[i].GetComponent<Renderer>().enabled = false;
	}
	}

void Update(){
CurrentHealth=player.GetComponent<PlayerMobility>().Hp;
if(CurrentHealth<0){
	CurrentHealth=0;
}
if(CurrentHealth>MaxHealth){
	CurrentHealth=MaxHealth;
}
for(int i=0; i<CurrentHealth; i++){
life(i);

}
for(int i=CurrentHealth; i<MaxHealth; i++){
death(i);

}


 

}


public void life(int i) {
    sr=Hearts[i].GetComponent<SpriteRenderer>();
	sr.sprite = HealthSprite;
}
    
public void death(int i) {
    sr=Hearts[i].GetComponent<SpriteRenderer>();
	sr.sprite = DeadSprite;
}

}
