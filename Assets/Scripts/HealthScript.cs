using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject[] Hearts;
	public GameObject[] UIHighlights;
	public GameObject player;
	public Sprite HealthSprite;
	public Sprite DeadSprite;
	private Image sr;
    public int MaxHealth;
	public int CurrentHealth;

	void Start(){
	for(int i=0; i<UIHighlights.Length; i++){
		UIHighlights[i].SetActive(false);
	}
	if(MaxHealth<=3){
	UIHighlights[0].SetActive(true);
	}
	else if(MaxHealth==4){
	UIHighlights[1].SetActive(true);
	}
	else if(MaxHealth==5){
	UIHighlights[2].SetActive(true);
	}
	else if(MaxHealth==4){
	UIHighlights[3].SetActive(true);
	}
	if(6<MaxHealth){
	MaxHealth=6;
    }
	CurrentHealth=MaxHealth;
	for(int i=MaxHealth; i<6; i++){
	Hearts[i].SetActive(false);
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
    sr=Hearts[i].GetComponent<Image>();
	sr.sprite = HealthSprite;
}
    
public void death(int i) {
    sr=Hearts[i].GetComponent<Image>();
	sr.sprite = DeadSprite;
}

}
