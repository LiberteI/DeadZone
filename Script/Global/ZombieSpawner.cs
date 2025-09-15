using UnityEngine;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{

    /*
        This script is responsible for spawning zombies.
    */

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float maxSpawnTimer;

    [SerializeField] private float curSpawnTimer;

    [SerializeField] private List<GameObject> runnerContainerPrefabs;

    [SerializeField] private List<GameObject> stalkerContainerPrefabs;

    [SerializeField] private List<GameObject> clutcherContainerPrefabs;

    [SerializeField] private GameObject tankContainerPrefab;

    [SerializeField] private GameObject boomerContainerPrefab;

    [SerializeField] private GameObject jockeyContainerPrefab;

    [SerializeField] private GameObject screamerContainerPrefab;

    [SerializeField] private GameObject poisonerContainerPrefab;

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


    private void TrySpawnZombie(List<GameObject> zombies)
    {
        if (curZombieCount <= 0)
        {
            return;
        }
        if (curSpawnTimer > 0)
        {
            return;
        }
        int maxIdx = zombies.Count;

        int randomIdx = UnityEngine.Random.Range(0, maxIdx);

        GameObject zombieContainer = zombies[randomIdx];

        GameObject curZombieContainer = Instantiate(zombieContainer, spawnPoint.position, Quaternion.identity);

        // add instantiated zombies to the list
        ZombieRecorder.curLevelZombies.Add(curZombieContainer);

        curZombieContainer.SetActive(true);

        curSpawnTimer = maxSpawnTimer;

        curZombieCount -= 1;
    }

    private void TrySpawnTank()
    {

    }

    private void TrySpawnBoomer()
    {

    }

    private void TrySpawnScreamer()
    {

    }

    private void TrySpawnPoisoner()
    {

    }
    
    private void TrySpawnJockey()
    {
        
    }
}
