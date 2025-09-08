using Unity.VisualScripting;
using UnityEngine;

public class SniperIdleState : SurvivorIState
{
    private Sniper survivor;

    private SniperParameter parameter;

    public SniperIdleState(Sniper survivor)
    {
        this.survivor = survivor;

        this.parameter = survivor.parameter;
    }
    public void OnEnter()
    {
        parameter.movementManager.DisableLinearVelocity();

        parameter.animator.Play("Idle");
    }

    public void OnUpdate()
    {
        if (survivor.isPlayedByPlayer)
        {
            return;
        }
        if (parameter.aiManager.shouldFollow)
        {
            survivor.TransitionState(SniperStateType.Walk);
            return;
        }
    }
    public void OnExit()
    {

    }

    public void HandleInput()
    {
        if(Input.GetKey("a") || Input.GetKey("d")){
            // if(Input.GetKey(KeyCode.LeftShift)){
            //     swat.TransitionState(SWATStateType.Run);
            //     return;
            // }
            survivor.TransitionState(SniperStateType.Walk);
            return;
        }
    }
}
public class SniperWalkState : SurvivorIState
{
    private Sniper survivor;

    private SniperParameter parameter;

    public SniperWalkState(Sniper survivor)
    {
        this.survivor = survivor;

        this.parameter = survivor.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        if (survivor.isPlayedByPlayer)
        {
            return;
        }
        if (!parameter.aiManager.shouldFollow)
        {
            survivor.TransitionState(SniperStateType.Idle);
            return;
        }

        parameter.movementManager.Walk(Mathf.Sign(parameter.aiManager.distance));
    }
    public void OnExit()
    {

    }

    public void HandleInput()
    {
        if(!(Input.GetKey("a") || Input.GetKey("d"))){
            survivor.TransitionState(SniperStateType.Idle);
            return;
        }
    }
}
