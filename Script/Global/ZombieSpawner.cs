using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class ZombieSpawner : MonoBehaviour
{

    /*
        This script is responsible for spawning zombies.
    */

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float maxSpawnTimer;

    [SerializeField] private float curSpawnTimer;

    [SerializeField] private List<GameObject> zombieContainerPrefabs;

    void Start()
    {
        curSpawnTimer = maxSpawnTimer;
    }

    void Update()
    {
        UpdateSpawnTimer();

        TrySpawn();
    }
    private void UpdateSpawnTimer()
    {
        if (curSpawnTimer > 0)
        {
            curSpawnTimer -= Time.deltaTime;
        }
    }
    
    private void TrySpawn()
    {
        if (curSpawnTimer > 0)
        {
            return;
        }
        int maxIdx = zombieContainerPrefabs.Count;

        int randomIdx = UnityEngine.Random.Range(0, maxIdx);

        GameObject zombieContainer = zombieContainerPrefabs[randomIdx];

        Instantiate(zombieContainer, spawnPoint.position, Quaternion.identity);

        curSpawnTimer = maxSpawnTimer;
    }
}
