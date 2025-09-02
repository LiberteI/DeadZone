using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class ZombieRecorder : MonoBehaviour
{

    public static List<GameObject> curLevelZombies = new List<GameObject>();


    private bool shouldStartTracking;

    private bool hasCleared;
    void OnEnable()
    {
        EventManager.OnStopSpawning += StartTracking;

        EventManager.OnBreakingDawn += StopTracking;

        EventManager.OnNightFall += StopTracking;

        EventManager.OnZombieDie += RemoveZombieFromTheList;
    }
    void OnDisable()
    {
        EventManager.OnStopSpawning -= StartTracking;

        EventManager.OnBreakingDawn -= StopTracking;

        EventManager.OnNightFall -= StopTracking;

        EventManager.OnZombieDie -= RemoveZombieFromTheList;
    }

    void Update()
    {
        TryCheckingLevelClearance();
    }

    private void StartTracking()
    {
        shouldStartTracking = true;
    }

    private void StopTracking(DayConfig config)
    {
        shouldStartTracking = false;

        hasCleared = false;
    }

    private void StopTracking(NightConfig config)
    {
        shouldStartTracking = false;

        hasCleared = false;
    }

    private void TryCheckingLevelClearance()
    {
        if (!shouldStartTracking)
        {
            return;
        }
        if (hasCleared)
        {
            return;
        }
        if (curLevelZombies.Count == 0)
        {
            hasCleared = true;

            EventManager.RaiseOnClearLevel();

            Debug.Log("level cleared, press p to continue");
        }
    }

    private void RemoveZombieFromTheList(GameObject deadZombie)
    {
        if (deadZombie == null)
        {
            Debug.Log("zombie to remove is null");
            return;
        }

        if (curLevelZombies.Contains(deadZombie))
        {
            curLevelZombies.Remove(deadZombie);
        }
        

        Destroy(deadZombie);
    }
}
