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

    // max zombie count should be instantiated
    private int maxZombieCount;

    // zombie count left to be instantiated
    private int curZombieCount;

    private bool hasStoppedSpawning = false;
    
    void OnEnable()
    {
        EventManager.OnBreakingDawn += SetMaxZombieCount;

        EventManager.OnNightFall += SetMaxZombieCount;
    }

    void OnDisable()
    {
        EventManager.OnBreakingDawn -= SetMaxZombieCount;

        EventManager.OnNightFall -= SetMaxZombieCount;
    }

    private void SetMaxZombieCount(DayConfig dayConfig)
    {
        maxZombieCount = dayConfig.zombieCount;

        curZombieCount = maxZombieCount;

        hasStoppedSpawning = false;
    }

    private void SetMaxZombieCount(NightConfig nightConfig)
    {
        maxZombieCount = nightConfig.zombieCount;

        curZombieCount = maxZombieCount;

        hasStoppedSpawning = false;
    }
    void Start()
    {
        curSpawnTimer = maxSpawnTimer;
    }

    void Update()
    {
        UpdateSpawnTimer();

        TrySpawn();

        TryRaiseLevelCleared();
    }

    private void TryRaiseLevelCleared()
    {
        if (curZombieCount > 0)
        {
            return;
        }

        if (hasStoppedSpawning)
        {
            return;

        }

        hasStoppedSpawning = true;

        EventManager.RaiseStopSpawning();

        Debug.Log("Has Stopped respawing, should start tracking if the list is empty");


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
        if (curZombieCount <= 0)
        {
            return;
        }
        if (curSpawnTimer > 0)
        {
            return;
        }
        int maxIdx = zombieContainerPrefabs.Count;

        int randomIdx = UnityEngine.Random.Range(0, maxIdx);

        GameObject zombieContainer = zombieContainerPrefabs[randomIdx];

        GameObject curZombieContainer = Instantiate(zombieContainer, spawnPoint.position, Quaternion.identity);

        // add instantiated zombies to the list
        ZombieRecorder.curLevelZombies.Add(curZombieContainer);

        curZombieContainer.SetActive(true);

        curSpawnTimer = maxSpawnTimer;

        curZombieCount -= 1;
    }
    
    
}
