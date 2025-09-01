using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

/*
    generic Zombie base.
*/
public abstract class BaseZombieParameter
{
    public Animator animator;

    public Rigidbody2D RB;

    public bool isFacingRight;

    public ZombieMeleeManager meleeManager;
}


public abstract class BaseZombie : MonoBehaviour
{
    protected IState currentState;

    public BaseZombieParameter parameter;

    void Update()
    {
        currentState.OnUpdate();
    }

}
