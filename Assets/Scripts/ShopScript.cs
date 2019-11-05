using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ShopScript : MonoBehaviour
{
private int Currency;
 
 private Image sr;
 public GameObject[] A1=new GameObject [3];
 public GameObject[] A2=new GameObject [3];
 public GameObject[] A3=new GameObject [3];
 public GameObject[] A4=new GameObject [3];
 public int [,] Preise= new int [4,3];
 public int [,] Kosten= new int [4,3];
 public Sprite boughts;
public Sprite canBuys;
public Sprite cannots;
	private int ShopWeaponCooldownReductionLevel;
	private int ShopItemSpawnCooldownReductionLevel;
	private int ItemDurationLevel;
	private int MaxHealth;

    // Start is called before the first frame update
    void Start()
    { 
	
	updateShop();
	}

	public void updateShop(){
	
	Currency=PlayerPrefs.GetInt("Currency", 0);
        ShopWeaponCooldownReductionLevel=PlayerPrefs.GetInt("FiringRateReductionLvl", 0);
        ShopItemSpawnCooldownReductionLevel=PlayerPrefs.GetInt("ItemSpawnRateReductionLvl", 0);
		ItemDurationLevel=PlayerPrefs.GetInt("ItemDurationIncreasementLvl", 0);
		MaxHealth=PlayerPrefs.GetInt("MaxHealth", 3);
		if(MaxHealth<3){
			MaxHealth=3;
			PlayerPrefs.SetInt("MaxHealth", 3);
		}

		
		//item duration
		Preise[0,0]=20;
		Preise[0,1]=50;
		Preise[0,2]=100;

		Preise[1,0]=20;
		Preise[1,1]=50;
		Preise[1,2]=100;

		Preise[2,0]=20;
		Preise[2,1]=50;
		Preise[2,2]=100;

		Preise[3,0]=20;
		Preise[3,1]=50;
		Preise[3,2]=100;

		for(int a=0; a<ItemDurationLevel; a++){
			Preise[0,a]=0;
		}
		for(int a=0; a<MaxHealth-3; a++){
			Preise[1,a]=0;
		}
		for(int a=0; a<ShopItemSpawnCooldownReductionLevel; a++){
			Preise[2,a]=0;
		}
		for(int a=0; a<ShopWeaponCooldownReductionLevel; a++){
			Preise[3,a]=0;
		}

		for(int z=0; z<4; z++){
        
		for(int y=0; y<3; y++){

		int sum=0;
		for(int i=0; i<1+y; i++){
		sum+=Preise[z,i];
		}
		Kosten[z,y]=sum;
		}
		}
		for(int i=0; i<3; i++){
		if(Kosten[0,i]==0){
		 bought(A1[i]);
		}else if(Kosten[0,i]<=Currency){
		can(A1[i]);
		}else{
		cannot(A1[i]);
		}
		}
		for(int i=0; i<3; i++){
		if(Kosten[1,i]==0){
		 bought(A2[i]);
		}else if(Kosten[1,i]<=Currency){
		can(A2[i]);
		}else{
		cannot(A2[i]);
		}
		}
		for(int i=0; i<3; i++){
		if(Kosten[2,i]==0){
		 bought(A3[i]);
		}else if(Kosten[2,i]<=Currency){
		can(A3[i]);
		}else{
		cannot(A3[i]);
		}
		}
		for(int i=0; i<3; i++){
		if(Kosten[3,i]==0){
		 bought(A4[i]);
		}else if(Kosten[3,i]<=Currency){
		can(A4[i]);
		}else{
		cannot(A4[i]);
		}

		}
		if(MaxHealth<6){
		GameObject.Find("Costs2").GetComponent<UnityEngine.UI.Text>().text = "Costs: "+Kosten[1,MaxHealth-3];
		}else{
			GameObject.Find("Costs2").SetActive(false);
			GameObject.Find("CostsButton2").SetActive(false);
			GameObject.Find("CostsImage2").SetActive(false);
		}
		if(ShopWeaponCooldownReductionLevel<3){
			GameObject.Find("Costs4").GetComponent<UnityEngine.UI.Text>().text = "Costs: "+Kosten[3,ShopWeaponCooldownReductionLevel];
		}else{
			GameObject.Find("Costs4").SetActive(false);
			GameObject.Find("CostsButton4").SetActive(false);
			GameObject.Find("CostsImage4").SetActive(false);
		}
		if(ShopItemSpawnCooldownReductionLevel<3){
		GameObject.Find("Costs3").GetComponent<UnityEngine.UI.Text>().text =  "Costs: "+Kosten[2,ShopItemSpawnCooldownReductionLevel];
		}else{
			GameObject.Find("Costs3").SetActive(false);
			GameObject.Find("CostsButton3").SetActive(false);
			GameObject.Find("CostsImage3").SetActive(false);
		}
		if(ItemDurationLevel<3){
		GameObject.Find("Costs1").GetComponent<UnityEngine.UI.Text>().text = "Costs: "+Kosten[0,ItemDurationLevel];
		}else{
		GameObject.Find("Costs1").SetActive(false);
		GameObject.Find("CostsButton1").SetActive(false);
		GameObject.Find("CostsImage1").SetActive(false);
		}
		
		
		
   
   
		
    }



	public void buyHP()
    {
        if(Currency>=Kosten[1,MaxHealth-3]&&MaxHealth<6){
			Currency-=Kosten[1,MaxHealth-3];
			MaxHealth++;
			PlayerPrefs.SetInt("MaxHealth", MaxHealth);
			PlayerPrefs.SetInt("Currency", Currency);
			updateShop();
		}
    }
	public void buyCD()
    {
	    
        if(Currency>=Kosten[3,ShopWeaponCooldownReductionLevel] && ShopWeaponCooldownReductionLevel<3){
			Currency-=Kosten[3,ShopWeaponCooldownReductionLevel];
			ShopWeaponCooldownReductionLevel++;
			PlayerPrefs.SetInt("FiringRateReductionLvl", ShopWeaponCooldownReductionLevel);
			PlayerPrefs.SetInt("Currency", Currency);
			updateShop();
		}
    }

		public void buyICR()
    {
        if(Currency>=Kosten[2,ShopItemSpawnCooldownReductionLevel] &&ShopItemSpawnCooldownReductionLevel <3){
			Currency-=Kosten[2,ShopItemSpawnCooldownReductionLevel];
			ShopItemSpawnCooldownReductionLevel++;
			PlayerPrefs.SetInt("ItemSpawnRateReductionLvl", ShopItemSpawnCooldownReductionLevel);
			PlayerPrefs.SetInt("Currency", Currency);
			updateShop();
		}
    }
			public void buyID()
    {
        if(Currency>=Kosten[0,ItemDurationLevel]&&ItemDurationLevel<3){
			Currency-=Kosten[0,ItemDurationLevel];
			ItemDurationLevel++;
			PlayerPrefs.SetInt("ItemDurationIncreasementLvl", ItemDurationLevel);
			PlayerPrefs.SetInt("Currency", Currency);
			updateShop();
		}
    }

	 public void bought(GameObject alpha)
    {
        sr=alpha.GetComponent<Image>();
	    sr.sprite = boughts;
    }

	public void can(GameObject alpha)
    {
        sr=alpha.GetComponent<Image>();
	    sr.sprite = canBuys;
    }

	 public void cannot(GameObject alpha)
    {
        sr=alpha.GetComponent<Image>();
	    sr.sprite = cannots;
    }

     public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
