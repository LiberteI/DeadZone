using UnityEngine;

public class PoisonerMovement : ZombieMovementMnager
{
    [SerializeField] private float sqrDistanceThreshold;

    // to prevent jittering
    [SerializeField] private float sqrThresholdOffset;

    [SerializeField] private bool shouldFollow;

    public bool shouldProject;

    private float dir;

    // range: curDistance : [threshold - offset, threshold + offset]

    
    void Update()
    {
        // cache target
        base.SetTarget();

        DefineFacingDir();

        FlipToTarget();

        DetermineMovementBehaviour();
    }

    private void DetermineMovementBehaviour()
    {
        if (base.zombie.parameter.isFacingRight)
        {
            dir = 1f;
        }
        else
        {
            dir = -1f;
        }
        // poisoner is too close: should flee
        if (base.zombie.parameter.aggroManager.curDistanceToTarget < sqrDistanceThreshold - sqrThresholdOffset)
        {
            shouldProject = false;
            
            shouldFollow = false;
        }
        // poisoner is too far: should follow
        else if (base.zombie.parameter.aggroManager.curDistanceToTarget > sqrDistanceThreshold + sqrThresholdOffset)
        {
            shouldProject = false;

            shouldFollow = true;
        }
        else
        {
            shouldProject = true;
        }
    }
    public override void Move()
    {
        if (shouldProject)
        {
            base.zombie.parameter.RB.linearVelocity = new Vector2(0, base.zombie.parameter.RB.linearVelocity.y);
            return;
        }
        base.zombie.parameter.RB.linearVelocity = new Vector2(speed * dir, base.zombie.parameter.RB.linearVelocity.y);

    }
    
    public override void FlipToTarget()
    {
        if (base.TargetIsNull())
        {
            return;
        }
        if (shouldProject)
        {

            base.FlipToTarget();
            return;
        }
        if (shouldFollow)
        {
            // flip to player
            if ((currentTarget.transform.position - transform.position).x > 0)
            {
                // target is to the right
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if ((currentTarget.transform.position - transform.position).x < 0)
            {
                // target is to the left
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }
        else
        {   
            // unflip to player
            if ((currentTarget.transform.position - transform.position).x > 0)
            {
                // target is to the right
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if ((currentTarget.transform.position - transform.position).x < 0)
            {
                // target is to the left
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
