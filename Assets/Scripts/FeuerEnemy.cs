using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuerEnemy : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Bulletboy;
    private double timeStamp=0;
    public double coolDownPeriodInSeconds;
	public static double CooldownReduction=0;
    
    // Update is called once per frame
    void Update()
    {                
        
     if (timeStamp <= Time.time)
     {
     frei();
     timeStamp = Time.time + coolDownPeriodInSeconds-(coolDownPeriodInSeconds*CooldownReduction);
     }
    
    }
    void frei()
    {
        Instantiate(BulletPrefab,Bulletboy.position,Bulletboy.rotation);
    }
}
