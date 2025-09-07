using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Jockey is a swift creeping infected, it jumps and controls the survivor. If lands on the survivor, it continuously apply scratch attacks, during which survivor cannot move.

    Jockey starts idling. It find a nearest target. And walks towards target. It has a sight box. 
        
        If the sight box detects the target. It caches target's position and try hunt the target, during which its control box is activated.

        If when jockey lands, target is within range of its control box. Disable target's movement. Jockey starts attacking.

        If jocky failed to control the player, start crowling and then do hunt again.

    Only ally shoots jockey can the controlled target break free
*/
[Serializable]
public class JockeyParameter : BaseZombieParameter
{
    public GameObject controlBox;
    public float huntDistThreshold;

    public float huntJumpYSpeed;

    public float huntJumpXSpeed;
}

public enum JockeyStateType
{
    Idle, Crawl, Attack, Hurt, Die, Jump, Hunt, Run
}
public class Jockey : BaseZombie
{
    public new JockeyParameter parameter;

    private Dictionary<JockeyStateType, IState> states = new Dictionary<JockeyStateType, IState>();

    public bool isHunting;

    void OnEnable()
    {
        base.parameter = parameter;
    }

    void Start()
    {
        states.Add(JockeyStateType.Idle, new JIdleState(this));

        states.Add(JockeyStateType.Crawl, new JCrawlState(this));

        states.Add(JockeyStateType.Jump, new JJumpState(this));

        states.Add(JockeyStateType.Hunt, new JHuntState(this));

        states.Add(JockeyStateType.Attack, new JAttackState(this));

        states.Add(JockeyStateType.Hurt, new JHurtState(this));

        states.Add(JockeyStateType.Die, new JDieState(this));

        states.Add(JockeyStateType.Run, new JRunState(this));

        TransitionState(JockeyStateType.Idle);
    }
    public void TransitionState(JockeyStateType newState)
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

    public void TryHunt()
    {
        StartCoroutine(ExecuteHunt());
    }
    /*
        1. calculate the distance between target and jockey. use the last calculation to conduct hunt.

        2. declare a duration, during which jockey move from start to the end.
    */
    private IEnumerator ExecuteHunt()
    {
        isHunting = true;

        // cache the distance on the x asix
        float distanceToLeap = parameter.aggroManager.curDistanceToTarget;

        Debug.Log($"Distance to leap : {distanceToLeap}");

        float distanceLeaped = 0;

        parameter.animator.Play("Jump");

        while (distanceLeaped < 0.5f * distanceToLeap)
        {   
            // x axis: calculate distance leaped
            distanceLeaped += parameter.huntJumpXSpeed * Time.deltaTime;

            // y axis: do reversed horizontal projectile motion
            float curYSpeed = Mathf.Lerp(parameter.huntJumpYSpeed, 0, distanceLeaped / (0.5f * distanceToLeap));

            // assign final speeds
            parameter.RB.linearVelocity = new Vector2(parameter.huntJumpXSpeed, curYSpeed);
            yield return null;
        }

        while (distanceLeaped < distanceToLeap)
        {
            // x axis: calculate distance leaped
            distanceLeaped += parameter.huntJumpXSpeed * Time.deltaTime;

            // y axis: do horizontal projectile motion
            float curYSpeed = Mathf.Lerp(0, -parameter.huntJumpYSpeed, distanceLeaped / distanceToLeap);

            // assign final speeds
            parameter.RB.linearVelocity = new Vector2(parameter.huntJumpXSpeed, curYSpeed);
            yield return null;
        }

        isHunting = false;
    }
}
