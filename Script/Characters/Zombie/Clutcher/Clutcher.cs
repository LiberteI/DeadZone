using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


/*
    Clutcher is the same as Runner regarding infected level, but their attack phase is to grab survivor and then stun them and bite.

    Zombie walks towards survivor, if survivor is in range, activate clutch collider.
        If overlaps, RaiseEvent Grabbed. Limit survivor movement until zombie is eliminated. Survivor cannot shoot but melee.
        

*/
public enum ClutcherStateType
{
    Walk, Die, Hurt, Clutch, Idle
}

[Serializable]
public class ClutcherParameter : BaseZombieParameter
{

}
public class Clutcher : BaseZombie
{
    // hides the base parameter
    public new ClutcherParameter parameter;

    private Dictionary<ClutcherStateType, IState> states = new Dictionary<ClutcherStateType, IState>();

    // cast base parameter to this parameter. prevent nullity
    void OnEnable()
    {
        base.parameter = parameter;
    }
    void Start()
    {
        states.Add(ClutcherStateType.Walk, new CWalkState(this));

        states.Add(ClutcherStateType.Die, new CDieState(this));

        states.Add(ClutcherStateType.Hurt, new CHurtState(this));

        states.Add(ClutcherStateType.Clutch, new CClutchState(this));

        states.Add(ClutcherStateType.Idle, new CIdleState(this));

        TransitionState(ClutcherStateType.Idle);
    }

    public void TransitionState(ClutcherStateType newState){
        // exit current state
        // Debug.Log($"Transition from {currentState} to {newState}");
        if(base.currentState != null){
            base.currentState.OnExit();
        }

        // assign new state from dictionary
        base.currentState = states[newState];

        // execute OnEnter once;
        base.currentState.OnEnter();
    }
}
