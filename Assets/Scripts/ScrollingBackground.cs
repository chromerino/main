﻿using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float reset=-20.325f;
<<<<<<< Updated upstream
    private float StartPoint=20.3251f;
    public float speed;
    void Update()
=======
    private float StartPoint=20.325f;
    public static float speed=-0.02f;
    void FixedUpdate()
>>>>>>> Stashed changes
    {
        if(reset>transform.position.x)
        {
            var correctPos =  reset-transform.position.x;
            transform.position=(new Vector3 (StartPoint-correctPos,0,0));
        }
        transform.position+= new Vector3(speed,0,0);
    }
   
}
