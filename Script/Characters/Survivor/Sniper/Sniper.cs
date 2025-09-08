using System;
using UnityEngine;
using System.Collections.Generic;

public enum SniperStateType
{
    Idle,
    Walk,
    Run,
    Crouch,
    Jump,
    Hurt,
    Die,
    StandShoot,
    CrouchShoot,
    Melee,
    Reload,
    Throw

}

[Serializable]
public class SniperParameter : SurvivorParameters
{
    public BaseMovementManager movementManager;
}
public class Sniper : SurvivorBase
{
    private Dictionary<SniperStateType, SurvivorIState> states = new Dictionary<SniperStateType, SurvivorIState>();

    public new SniperParameter parameter;

    void Awake()
    {
        base.parameter = parameter;

        SurvivorManager.survivorList.Add(parameter.survivorContainer);
    }

    void Start()
    {
        states.Add(SniperStateType.Idle, new SniperIdleState(this));

        states.Add(SniperStateType.Walk, new SniperWalkState(this));

        TransitionState(SniperStateType.Idle);
    }

    public void TransitionState(SniperStateType newState)
    {
        // exit current state
        // Debug.Log($"Transition from {currentState} to {newState}");
        if (base.currentState != null)
        {
            base.currentState.OnExit();
        }

        // assign new state from dictionary
        base.currentState = states[newState];

        // execute OnEnter once;
        base.currentState.OnEnter();
    }
}
