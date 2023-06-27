using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjectList;
    [SerializeField] private Transform[] spawnPoints;
    public float spawnWaitTime;     //Time Between Spawns
    public float initialSpawnWait; //Waiting Time Before The Spawning Starts

    private float lastSpawnTime; //Time When The Last Spawn Happened

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        //If Enough Time Passed After LastSpawnTime, Spawn A New Object
        if (Time.time - lastSpawnTime >= spawnWaitTime)
        {
            SpawnObject();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnObjectList.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(spawnObjectList[randomIndex], spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);
    }

    public void SpawnObjectInstalty()
    {
        int randomIndex = Random.Range(0, spawnObjectList.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        
        Instantiate(spawnObjectList[randomIndex], spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);
        lastSpawnTime = Time.time; //Necessary Reset In Order To Avoid Another Spawn Instantly
    }
}
