using UnityEngine;

public class NZIdleState : IState
{   
    private NormalZombie zombie;

    private NormalZombieParameter parameter;

    public NZIdleState(NormalZombie zombie){
        this.zombie = zombie;

        this.parameter = zombie.parameter;
    }
    public void OnEnter(){
        parameter.animator.Play("Idle");
    }
    public void OnUpdate(){
        if(parameter.meleeManager.SurvivorIsInRange()){
            zombie.TransitionState(NormalZombieStateTypes.Attack);
        }
    }
    public void OnExit(){

    }
}

public class NZWalkState : IState
{   
    private NormalZombie zombie;

    private NormalZombieParameter parameter;

    public NZWalkState(NormalZombie zombie){
        this.zombie = zombie;

        this.parameter = zombie.parameter;
    }
    public void OnEnter(){

    }
    public void OnUpdate(){

    }
    public void OnExit(){

    }
}
public class NZHurtState : IState
{   
    private NormalZombie zombie;

    private NormalZombieParameter parameter;

    public NZHurtState(NormalZombie zombie){
        this.zombie = zombie;

        this.parameter = zombie.parameter;
    }
    public void OnEnter(){

    }
    public void OnUpdate(){

    }
    public void OnExit(){

    }
}
public class NZDieState : IState
{   
    private NormalZombie zombie;

    private NormalZombieParameter parameter;

    public NZDieState(NormalZombie zombie){
        this.zombie = zombie;

        this.parameter = zombie.parameter;
    }
    public void OnEnter(){

    }
    public void OnUpdate(){

    }
    public void OnExit(){

    }
}
public class NZAttackState : IState
{   
    private NormalZombie zombie;

    private NormalZombieParameter parameter;

    private AnimatorStateInfo info;

    public NZAttackState(NormalZombie zombie){
        this.zombie = zombie;

        this.parameter = zombie.parameter;
    }
    public void OnEnter(){
        parameter.animator.Play("Attack");
    }
    public void OnUpdate(){
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if(!info.IsName("Attack")){
            return;
        }
        if(info.normalizedTime > 1f){
            zombie.TransitionState(NormalZombieStateTypes.Idle);
            return;
        }
    }
    public void OnExit(){

    }
}


