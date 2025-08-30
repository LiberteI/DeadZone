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

    }
    public void OnUpdate(){

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

    public NZAttackState(NormalZombie zombie){
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


