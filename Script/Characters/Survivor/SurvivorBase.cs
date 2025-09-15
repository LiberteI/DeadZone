using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public class SurvivorParameters
{
    public Rigidbody2D RB;

    public Animator animator;

    public SurvivorAI aiManager;

    public bool isFacingRight;

    public GameObject survivorContainer;
}
public class SurvivorBase : MonoBehaviour
{
    protected SurvivorIState currentState;

    public SurvivorParameters parameter;

    public bool isPlayedByPlayer;

    public int curFloor = 1;
    void Update()
    {
        // Debug.Log(parameter);
        currentState.OnUpdate();

        if (!isPlayedByPlayer)
        {
            return;
        }
        currentState.HandleInput();
    }
    void OnEnable()
    {
        EventManager.OnFloorChanged += UpdateCurFloor;
    }

    void OnDisable()
    {
        EventManager.OnFloorChanged -= UpdateCurFloor;
    }
    private void UpdateCurFloor(GameObject obj, bool shouldIncrement)
    {
        if (obj != this.gameObject)
        {
            return;
        }

        if (shouldIncrement)
        {
            curFloor += 1;
        }
        else
        {
            curFloor -= 1;
        }
    }
}