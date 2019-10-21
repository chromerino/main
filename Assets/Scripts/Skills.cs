using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private int Hp;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
            reduceHp();
    }
    private void reduceHp()
    {
        Hp -= 1;
    }
}
