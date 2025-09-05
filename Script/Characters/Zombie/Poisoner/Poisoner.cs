using System;
using System.Collections.Generic;
using UnityEngine;

/*
    Poisoner will spray poisonous chemicals that cause range effect. Inspired by Left 4 Dead.

    poisoner starts Idling. 

    Poisoner calculate its distance between the nearest survivor in the horizontal direction.
        Update per 5 seconds. if it is too near, walk away, if too far, walk little close.

    if survivor walks up too close, it attacks survivor.

    It adjust its position every 5 seconds and project poisonous projections.

    the projection will explode once it reach the ground. and it remains there for a couple of minutes

    After its death, it will leave a poisonous cluster of smoke for seconds.
*/
public enum PoisonerStateType
{
    Idle, Walk, Attack, Project, Hurt, Die, Jump
}

[Serializable]
public class PoisonerParameter : BaseZombieParameter
{
    
}
public class Poisoner : BaseZombie
{
    public new PoisonerParameter parameter;

    private Dictionary<PoisonerStateType, IState> states = new Dictionary<PoisonerStateType, IState>();

    void OnEnable()
    {
        base.parameter = parameter;
    }

    void Start()
    {
        states.Add(PoisonerStateType.Idle, new PIdleState(this));

        states.Add(PoisonerStateType.Walk, new PWalkState(this));

        states.Add(PoisonerStateType.Attack, new PAttackState(this));

        states.Add(PoisonerStateType.Project, new PProjectState(this));

        states.Add(PoisonerStateType.Hurt, new PHurtState(this));

        states.Add(PoisonerStateType.Die, new PDieState(this));

        states.Add(PoisonerStateType.Jump, new PJumpState(this));

        TransitionState(PoisonerStateType.Idle);
    }

    public void TransitionState(PoisonerStateType newState)
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
