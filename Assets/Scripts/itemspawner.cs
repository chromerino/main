using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnSpots;
    public GameObject[] items;
    private float timeBtwSpawns;
        public float startTimeBtwSpawns;
    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length-1);
            int randPos2= Random.Range(0, items.Length-1) ;
            Instantiate(items[randPos2], spawnSpots[randPos].position, spawnSpots[randPos].rotation);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}
