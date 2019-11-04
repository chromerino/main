using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllScript : MonoBehaviour
{
public static int lastScore=0;
private float timeStamp=0;
private int mult=1;
private int Score=0;
private double lategameMult;
private double timeStampLateGame=0;
private double StartTime;

public static int ShopWeaponCooldownReductionLevel=0;


    // Start is called before the first frame update

    void Start()
    {
	    lategameMult=0;
        FEUER.coolDownPeriodInSeconds = (float)(1 - (0.1 * ShopWeaponCooldownReductionLevel));// - lMult;
        itemspawner.startTimeBtwSpawns = (float)15;//- 15 * lMult;
        PlayerMobility.runSpeed = (float)4;//+ 4 * lMult;
        FeuerEnemy.CooldownReduction = 1;//lMult;
        SpeedyBoy.speed = (float)0.1f; //+ (0.1f * lMult);
        Spawner.startTimeBtwSpawns = (float)4; //- 4 * lMult;

        SpeedyBoy.speed = -0.02f;
        ScrollingBackground.speed =  - 0.02f;
        scrollingItem.speed = -0.02f;
        Enemy.speed = -0.02f;
		StartTime=Time.time;
		
    }
    // Update is called once per frame
    void FixedUpdate(){
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed==true){
	mult=3;
	}else{
		mult=1;
	}

	if (timeStamp <= Time.time)
     {

	   Score+=(1*mult);
       timeStamp+=0.01f;

     }
	 GameObject.Find("ScoreCountText").GetComponent<UnityEngine.UI.Text>().text = ""+Score;
        
		if (timeStampLateGame <= Time.time)
     {
	  
	   lategameMult=0.70-(7/(10+(Time.time-StartTime)/5));
	   Debug.Log(lategameMult);
	  
	   increment();
       timeStampLateGame+=1;

     }

    }

	public void addKill(){
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed==true){
	mult=3;
	}else{
		mult=1;
	}
	Score+=(500*mult);
	}

	public void addItem(){
	if(GameObject.Find("HealthUI").GetComponent<HealthScript>().fullHealed==true){
	mult=3;
	}else{
		mult=1;
	}
	Score+=(150*mult);
	}

	public void end(){
		lastScore=Score;

	}

		public void increment()
		{
		string result = lategameMult.ToString("0.0000");
		float lMult=float.Parse(result);
	    float speed=(float)-0.02f+(-0.02f*lMult);
		
            
		
		FEUER.coolDownPeriodInSeconds=(float)(1-(0.1*ShopWeaponCooldownReductionLevel))-lMult;
		itemspawner.startTimeBtwSpawns=(float)15-15*lMult;
		PlayerMobility.runSpeed=(float)4+4*lMult;
		FeuerEnemy.CooldownReduction=lMult;
		SpeedyBoy.speed= (float)0.1f+(0.1f*lMult);
		Spawner.startTimeBtwSpawns=(float) 4-4*lMult;

		SpeedyBoy.speed= speed;
	    ScrollingBackground.speed= speed;
		scrollingItem.speed= speed;
		Enemy.speed= speed;

	}

}
