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
}