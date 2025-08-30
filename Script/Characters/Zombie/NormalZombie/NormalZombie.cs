using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

[Serializable]
public class NormalZombieParameter : BaseZombieParameter{

}

public class NormalZombie : BaseZombie
{   
    public NormalZombieParameter parameter;

    void Start(){
        base.states.Add(ZombieStateType.Idle , new NZIdleState(this));

        base.states.Add(ZombieStateType.Walk , new NZWalkState(this));

        base.states.Add(ZombieStateType.Attack , new NZAttackState(this));

        base.states.Add(ZombieStateType.Hurt , new NZAttackState(this));

        base.states.Add(ZombieStateType.Die , new NZDieState(this));

        base.TransitionState(ZombieStateType.Idle);
    }
}
