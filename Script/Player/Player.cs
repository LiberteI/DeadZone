using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
/*
    This script is the cross road linking Managers and parameters.
*/
public enum PlayerStateType{
    Idle,
    Walk,
    Run,
    Hurt,
    Die,
    StandShoot,
    CrouchShoot,
    Kick,
    Reload,
    Jump,
    Crouch
}
[Serializable]
public class Parameters{

    public Rigidbody2D RB;

    public Animator animator;

    public MovementManager movementManager;

    public ShootingManager shootingManager;

    public Transform standMuzzle;

    public Transform crouchMuzzle;

    
    // universal bool
    public bool isShooting;

    public bool isReloading;

    public bool isKicking;

    public bool isFacingRight;

    public bool isCrouching;
}


public class Player : MonoBehaviour
{

    public Parameters parameter;

    private PlayerIState currentState;

    private Dictionary<PlayerStateType, PlayerIState> states = new Dictionary<PlayerStateType, PlayerIState>();
    
    void Start()
    {   
        // add states into the dictionary, taking a parameter of Player script
        states.Add(PlayerStateType.Idle, new IdleState(this));
        states.Add(PlayerStateType.Walk, new WalkState(this));
        states.Add(PlayerStateType.Run, new RunState(this));
        states.Add(PlayerStateType.Hurt, new HurtState(this));
        states.Add(PlayerStateType.Die, new DieState(this));
        states.Add(PlayerStateType.StandShoot, new StandShootState(this));
        states.Add(PlayerStateType.CrouchShoot, new CrouchShootState(this));
        states.Add(PlayerStateType.Kick, new KickState(this));
        states.Add(PlayerStateType.Reload, new ReloadState(this));
        states.Add(PlayerStateType.Jump, new JumpState(this));
        states.Add(PlayerStateType.Crouch, new CrouchState(this));

        currentState = states[PlayerStateType.Idle];
    }

    
    void Update()
    {
        currentState.OnUpdate();
        currentState.HandleInput();
    }

    public void TransitionState(PlayerStateType newState){
        // exit current state
        Debug.Log($"Transition from {currentState} to {newState}");
        if(currentState != null){
            currentState.OnExit();
        }

        // assign new state from dictionary
        currentState = states[newState];

        // execute OnEnter once;
        currentState.OnEnter();
    }
}
