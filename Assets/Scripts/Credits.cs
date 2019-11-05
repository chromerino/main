using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    double time;
    // Start is called before the first frame update
    void Start()
    {
        time=Time.time+32;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position+= new Vector3(0,2,0);
        if(time<Time.time){
            SceneManager.LoadScene("MainMenu");
        }  
    }
}
