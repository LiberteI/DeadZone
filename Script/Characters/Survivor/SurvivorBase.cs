using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public class SurvivorParameters
{
    public Rigidbody2D RB;

    public Animator animator;

    public bool isPlayedByPlayer;

    public bool isFacingRight;

    public GameObject survivorContainer;
}
public class SurvivorBase : MonoBehaviour
{
    protected SurvivorIState currentState;

    public SurvivorParameters parameter;

    void Update()
    {
        // Debug.Log(parameter);
        currentState.OnUpdate();

        if (!parameter.isPlayedByPlayer)
        {
            return;
        }
        currentState.HandleInput();
    }
}