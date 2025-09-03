using UnityEngine;


/*
    generic Zombie base.
*/

/*  
    Defined Zombie Types: 
        1. Runner is the most primary level infected. They will initiat attacks with their fist or simply bite survivors.

        2. Clutcher is the same as Runner regarding infected level, but their attack phase is to grab survivor and then stun them and bite.

        3. Screamer will use scream to summon lots of infected.

        4. Spitter will spray poisonous chemicals that cause range effect. Inspired by Left 4 Dead.

        5. Jockey is a swift creeping infected, it jumps and controls the survivor. If lands on the survivor, it continuously apply scratch attacks / bite survivors on the ground.

        6. Boomer used to be a scientist working in lab. After getting infected, the virus gets trapped inside its suit. Boomer is extremely fragile. Getting hit, it will explode and its
            remain liquid will cause other infected to switch aggro.

        7. Stalker is the same as Runner regarding infected level, but they have swifter speed and higher damage.

        8. Tank's chest is busted open with tusks. It has the highest health volume and the way it attacks is to swing fist or grab survivor with its tusks.
*/
public enum ZombieType
{
    Runner, Clutcher, Screamer, Spitter, Jockey, Boomer, Stalker, Tank
}
public abstract class BaseZombieParameter
{
    public Animator animator;

    public Rigidbody2D RB;

    public bool isFacingRight;

    public ZombieMeleeManager meleeManager;

    public ZombieAggroManager aggroManager;

    public ZombieMovementMnager movementManager;
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
