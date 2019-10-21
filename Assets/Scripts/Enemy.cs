using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float reset=-9f;
    private Transform playerPos;
    public float minY;
    public float maxY;
    public bool border;
    private PlayerMobility player;
    public int health=2;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMobility>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    /**void update()

    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position ,speed * Time.deltaTime);
    }**/

    void Update()
    {
        //transform.rotation= new Quaternion(0,0,90,90);
        transform.position+= new Vector3(speed,0,0);
        if (border ==true && transform.position.y<5)
        {
            transform.position=new Vector2(transform.position.x,Mathf.Clamp(transform.position.y,minY,maxY));
        }
        if(transform.position.x<=reset&& transform.position.y<4)
        {
          Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.Hp--;
            health--;
            if(health<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
