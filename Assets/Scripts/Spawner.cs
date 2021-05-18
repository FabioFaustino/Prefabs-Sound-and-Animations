using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int spawnDelay = 5; //seconds
    [SerializeField]
    private Vector3 spawnValues;
    [SerializeField]
    private int maxObjectsSpawned = 20;
    [SerializeField]
    private int simultaneousSpawnObjects = 1;
    [SerializeField]
    private int secondsToIncreaseSpawns = 20;

    private int currentSpawnedObjects = 0;

    ObjectPooler objectPooler;

    private float currentTimeSinceLastSpawn = 0.0f;

    private float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTimeSinceLastSpawn += Time.deltaTime;
        currentTime += Time.deltaTime;

        if (CanSpawn())
        {
            Debug.Log("Spawning");
            Spawn();
            currentTimeSinceLastSpawn = 0.0f;
            currentSpawnedObjects++;
        }
    }

    public void Reset()
    {
        currentSpawnedObjects = 0;
    }
    private bool CanSpawn()
    {
        return currentTimeSinceLastSpawn >= spawnDelay && currentSpawnedObjects < maxObjectsSpawned;
    }

    private void Spawn()
    {       
        for(int i = 0; i < simultaneousSpawnObjects; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            objectPooler.SpawnFromPool("Enemy", spawnPosition, Quaternion.identity);
        }        
    }

    private void IncreaseSpawns()
    {
        if (currentTime > secondsToIncreaseSpawns)
        {
            simultaneousSpawnObjects++;
            currentTime = 0;
        }
    }
}
