using UnityEngine;

public class PIdleState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    private float random;

    public PIdleState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
    }
    public void OnEnter()
    {
        random = UnityEngine.Random.Range(0, 100);

        if (random > 50f)
        {
            parameter.animator.Play("Idle2");
        }
        else
        {
            parameter.animator.Play("Idle");
        }
    }

    public void OnUpdate()
    {
        if (parameter.aggroManager.currentTarget == null)
        {
            return;
        }
        if (parameter.meleeManager.SurvivorIsInRange())
        {
            poisoner.TransitionState(PoisonerStateType.Attack);
            return;
        }
        poisoner.TransitionState(PoisonerStateType.Walk);
    }

    public void OnExit()
    {

    }
}

public class PWalkState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PWalkState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        parameter.movementManager.Move();

        
    }

    public void OnExit()
    {

    }
}

public class PAttackState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PAttackState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
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

public class PProjectState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PProjectState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
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

public class PHurtState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PHurtState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
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

public class PDieState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PDieState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
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

public class PJumpState : IState
{
    private Poisoner poisoner;

    private PoisonerParameter parameter;

    public PJumpState(Poisoner poisoner)
    {
        this.poisoner = poisoner;

        this.parameter = poisoner.parameter;
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

