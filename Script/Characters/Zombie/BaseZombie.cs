using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

/*
    generic Zombie base.
*/
public abstract class BaseZombieParameter{
    public Animator animator;

    public Rigidbody2D RB;
}

public enum ZombieStateType{
    // base enums:
    Attack, Hurt, Die, Idle, Walk
}
public abstract class BaseZombie : MonoBehaviour
{
    protected IState currentState;

    protected Dictionary<ZombieStateType, IState> states = new Dictionary<ZombieStateType, IState>();

    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(ZombieStateType newState){
        // exit current state
        // Debug.Log($"Transition from {currentState} to {newState}");
        if(currentState != null){
            currentState.OnExit();
        }

        // assign new state from dictionary
        currentState = states[newState];

        // execute OnEnter once;
        currentState.OnEnter();
    }
}
