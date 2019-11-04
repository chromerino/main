using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] enemies;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
        public static float startTimeBtwSpawns=4;
    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    void FixedUpdate()
    {
        if(timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
			int randPos2 = Random.Range(0, enemies.Length);
            Instantiate(enemies[randPos2], spawnSpots[randPos].position, spawnSpots[randPos].rotation);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}
