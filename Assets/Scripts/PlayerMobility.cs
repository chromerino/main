using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public bool border;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int Hp=5;
    
    private float maxHeight;
 
    private void FixedUpdate()
    {
        
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
        
        var upperCorner = new Vector2(Screen.width, Screen.height);
        var rawUC = Camera.main.ScreenToWorldPoint(upperCorner);
        maxHeight = rawUC.y;
        var charHeight = GetComponent<Renderer>().bounds.extents.y;
        maxHeight = rawUC.y - charHeight; 
        if(Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    
}

