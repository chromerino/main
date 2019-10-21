﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyBoy : MonoBehaviour
{
    public float speed;
    private float resetl = -9f;
    private float resetR = 9f;
    public float bulletSpeed;
    private PlayerMobility player;
    // Start is called before the first frame update
    void FixedUpdate()
    {

        if (transform.position.x <= resetl || transform.position.x >= resetR)
        {
            Destroy(this.gameObject);
        }
        float x = transform.eulerAngles.z;
        print(x);
        x -= 90;
        x *= Mathf.PI / 180;
        
        var rotatedVector = bulletSpeed * new Vector3(Mathf.Cos(x), Mathf.Sin(x), 0);
       

        transform.position += new Vector3(speed, 0, 0) + rotatedVector;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Hp--;
            Debug.Log(player.Hp);
            Destroy(this.gameObject);
        }
    }

}
