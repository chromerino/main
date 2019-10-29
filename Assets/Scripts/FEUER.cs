using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUER : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Bulletboy;
     private double timeStamp=0;
     private double burstStamp=0;
     private double burstStamp2=0;
     private bool ShotsFired=false;
    public double coolDownPeriodInSeconds;
    // Update is called once per frame
    void FixedUpdate()
    {        
        if(GameObject.Find("Player").GetComponent<PlayerMobility>().burstfire==true)
     {
         if(ShotsFired==false){
         if (burstStamp2 <= Time.time) 
         {frei();
         ShotsFired=true;
         }
         else if(burstStamp <= Time.time)
         {
             frei();
         }
         }
     }
        if(Input.GetButtonDown("Rammstein"))
        {
             
     if (timeStamp <= Time.time  ||GameObject.Find("Player").GetComponent<PlayerMobility>().reduction==true)
     {
     frei();
     timeStamp = Time.time + coolDownPeriodInSeconds;
     if(GameObject.Find("Player").GetComponent<PlayerMobility>().burstfire==true)
     {
        burstStamp=Time.time+0.1;
        burstStamp2=Time.time+0.2;
        ShotsFired=false;
     }
     
     }
             
        }
        
    }
    void frei()
    {
        Instantiate(BulletPrefab,Bulletboy.position,Bulletboy.rotation);
    }
}
