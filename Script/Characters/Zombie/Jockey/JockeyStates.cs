using UnityEditorInternal;
using UnityEngine;

public class JIdleState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JIdleState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("Idle");
    }
    public void OnUpdate()
    {
        if (parameter.aggroManager.currentTarget == null)
        {
            return;
        }

        if (parameter.meleeManager.SurvivorIsInRange())
        {
            jockey.TransitionState(JockeyStateType.Attack);
        }

        jockey.TransitionState(JockeyStateType.Crawl);
    }
    public void OnExit()
    {

    }
}

public class JCrawlState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    private float timer;

    public JCrawlState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {
        timer = 1.5f;

        parameter.animator.Play("Walk");
    }
    public void OnUpdate()
    {
        parameter.movementManager.Move();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        jockey.TransitionState(JockeyStateType.Hunt);
    }
    public void OnExit()
    {
        timer = 1.5f;
    }
}

public class JJumpState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JJumpState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}


public class JHuntState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JHuntState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {
        jockey.TryHunt();
    }
    public void OnUpdate()
    {
        if (jockey.isHunting)
        {
            return;
        }
        parameter.movementManager.DisableLinearVelocity();

        // jockey.TransitionState(JockeyStateType.Idle);
    }
    public void OnExit()
    {

    }
}

public class JAttackState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JAttackState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class JHurtState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JHurtState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class JDieState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JDieState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class JRunState : IState
{
    private Jockey jockey;

    private JockeyParameter parameter;

    public JRunState(Jockey jockey)
    {
        this.jockey = jockey;

        this.parameter = jockey.parameter;
    }

    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}
