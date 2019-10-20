using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUER : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Bulletboy;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Rammstein"))
        {
            frei();  
        }
        
    }
    void frei()
    {
        Instantiate(BulletPrefab,Bulletboy.position,Bulletboy.rotation);
    }
}
