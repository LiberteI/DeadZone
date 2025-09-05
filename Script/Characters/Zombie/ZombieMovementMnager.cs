using UnityEngine;

public class ZombieMovementMnager : MonoBehaviour
{
    [SerializeField] protected BaseZombie zombie;

    protected GameObject currentTarget;

    public float speed;
    
    void Start()
    {
        speed = UnityEngine.Random.Range(3f, 5f);
        
    }
    void Update()
    {
        // cache target
        SetTarget();

        DefineFacingDir();

        FlipToTarget();
    }

    protected bool TargetIsNull()
    {
        if (zombie.parameter.aggroManager.currentTarget == null)
        {
            return true;
        }
        return false;
    }
    private void DefineFacingDir()
    {
        if (transform.eulerAngles.y == 0)
        {
            zombie.parameter.isFacingRight = true;
            return;
        }
        if (transform.eulerAngles.y == 180f)
        {
            zombie.parameter.isFacingRight = false;
            return;
        }
    }

    private void SetTarget()
    {
        if (zombie.parameter == null)
        {
            Debug.Log("parameter is null");
            return;
        }
        if (this.currentTarget != zombie.parameter.aggroManager.currentTarget)
        {
            if (zombie.parameter.aggroManager.currentTarget == null)
            {
                this.currentTarget = null;
                return;
            }

            this.currentTarget = zombie.parameter.aggroManager.currentTarget;
        }
    }
    protected virtual void FlipToTarget()
    {
        if (TargetIsNull())
        {
            return;
        }
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

    public virtual void Move()
    {
        float dir = 0;
        if (zombie.parameter.isFacingRight)
        {
            dir = 1f;
        }
        else
        {
            dir = -1f;
        }
        zombie.parameter.RB.linearVelocity = new Vector2(speed * dir, zombie.parameter.RB.linearVelocity.y);
    }

    public void DisableLinearVelocity()
    {
        if (zombie.parameter == null)
        {
            Debug.Log("parameter is null");
            return;
        }
        zombie.parameter.RB.linearVelocity = Vector2.zero;
    }
}
