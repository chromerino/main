using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed=  -0.02f;
    public float rotateSpeed;
    private float reset=-9f;
    private Transform playerPos;
    public float minY;
    public float maxY;
    public bool border;
    private PlayerMobility player;
    public int health=2;
    
    
    
    
    private void Start()
    {
	/*
        PlayerMobility playerMobility = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMobility>();
        player = playerMobility;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		*/
    }
 

    void FixedUpdate()
    {
        transform.position+= new Vector3(speed,0,0);
        playerPos = GameObject.Find("Player").transform;
        Vector2 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if((angle + 270) % 360>=210)
        {
            angle = 360 - (angle + 270) % 360;
        }
        else
        {
            angle = (angle + 270) % 360;
        }
        
        Quaternion rotation = Quaternion.AngleAxis(Mathf.Clamp(angle,30,150), Vector3.forward);
        transform.rotation= Quaternion.Slerp(transform.rotation,rotation,rotateSpeed * Time.deltaTime);
        if (border ==true && transform.position.y<5)
        {
            transform.position=new Vector2(transform.position.x,Mathf.Clamp(transform.position.y,minY,maxY));
        }
        if(transform.position.x<=reset&& transform.position.y<4)
        {
          Destroy(this.gameObject);
        }
        if(health<=0)
            {
			    GameObject.Find("CurrencyText").GetComponent<Currency>().increment();
				GameObject.Find("GameControll").GetComponent<GameControllScript>().addKill();
                Destroy(this.gameObject);
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
		    player= other.gameObject.GetComponent<PlayerMobility>();
            player.Hp--;
            health--;
            
        }
    }

}
