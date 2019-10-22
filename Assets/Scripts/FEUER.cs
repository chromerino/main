using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUER : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Bulletboy;
     private double timeStamp=0;
    public double coolDownPeriodInSeconds;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Rammstein"))
        {
               
     if (timeStamp <= Time.time)
     {
     frei();
     timeStamp = Time.time + coolDownPeriodInSeconds;
     }
             
        }
        
    }
    void frei()
    {
        Instantiate(BulletPrefab,Bulletboy.position,Bulletboy.rotation);
    }
}
