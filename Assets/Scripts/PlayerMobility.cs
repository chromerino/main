using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMobility : MonoBehaviour
{
    public bool border;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int Hp=5;
    
    private double timeStamp=0;
    public double coolDownPeriodInSeconds; 
    private float maxHeight;
    public bool invincible=false;
    public bool burstfire=false;
    public bool reduction=false;
 
    private void FixedUpdate()
    {
           
     if (timeStamp <= Time.time)
     {
       reduction=false;
       burstfire=false;
       invincible=false;
     }
        float runSpeed = 4f;
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 vel = new Vector2(moveH * runSpeed, moveV * runSpeed).normalized;

        vel *= runSpeed;

        GetComponent<Rigidbody2D>().velocity = vel;

        if (border ==true)
        {
            transform.position=new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),Mathf.Clamp(transform.position.y,minY,maxY),transform.position.z);
        }
        if(Hp<=0)
        {
            SceneManager.LoadScene("GameOverMenu");
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CDR reduction"))
        {
            timeStamp = Time.time + 5;
            reduction=true;
            Destroy(other.gameObject);
           
        } else if(other.CompareTag("Burstfire"))
        {
            timeStamp = Time.time + 5;
            burstfire=true;
            Destroy(other.gameObject);
        } else if(other.CompareTag("Invincibility"))
        {
            timeStamp = Time.time + 5;
             invincible=true;
             Destroy(other.gameObject);
        }else if(other.CompareTag("RepairItem"))
        {
            Hp++;
            Destroy(other.gameObject);
        }
    }
    
}

