using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingItem : MonoBehaviour
{
    public float speed;
    private float reset=-9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position+= new Vector3(speed,0,0);  
      if(transform.position.x<=reset&& transform.position.y<4)
        {
          Destroy(this.gameObject);
        }
    }
}
