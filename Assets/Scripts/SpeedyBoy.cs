using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyBoy : MonoBehaviour
{
    public static float speed=-0.02f;
    private float resetl = -9f;
    private float resetR = 9f;
    public static float bulletSpeed=0.1f;
    public Enemy enemy;
    public PlayerMobility player;
	public int Damage;
    // Start is called before the first frame update
    void FixedUpdate()
    {

        if (transform.position.x <= resetl || transform.position.x >= resetR)
        {
            Destroy(this.gameObject);
        }
        float x = transform.eulerAngles.z;
        x -= 90;
        x *= Mathf.PI / 180;
        
        var rotatedVector = bulletSpeed * new Vector3(Mathf.Cos(x), Mathf.Sin(x), 0);
       

        transform.position += new Vector3(speed, 0, 0) + rotatedVector;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health--;
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player"))
        {
           player= other.gameObject.GetComponent<PlayerMobility>();
           if(player.invincible==false)
           {
            player.Hp-=Damage;
           }
            Destroy(this.gameObject); 
        }
    } 

}
