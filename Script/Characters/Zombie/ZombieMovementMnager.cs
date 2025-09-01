using UnityEngine;

public class ZombieMovementMnager : MonoBehaviour
{
    [SerializeField] private BaseZombie zombie;

    private BaseZombieParameter parameter;

    private GameObject currentTarget;

    [SerializeField] private float walkSpeed;
    void Awake()
    {
        parameter = zombie.parameter;
    }
    void Start()
    {
        walkSpeed = UnityEngine.Random.Range(3f, 5f);
        
    }
    void Update()
    {
        // cache target
        SetTarget();

        DefineFacingDir();

        FlipToTarget();
    }

    private bool TargetIsNull()
    {
        if (parameter.aggroManager.currentTarget == null)
        {
            return true;
        }
        return false;
    }
    private void DefineFacingDir()
    {
        if (transform.eulerAngles.y == 0)
        {
            parameter.isFacingRight = true;
            return;
        }
        if (transform.eulerAngles.y == 180f)
        {
            parameter.isFacingRight = false;
            return;
        }
    }

    private void SetTarget()
    {
        if (this.currentTarget != parameter.aggroManager.currentTarget)
        {
            if (parameter.aggroManager.currentTarget == null)
            {
                this.currentTarget = null;
                return;
            }
            
            this.currentTarget = parameter.aggroManager.currentTarget;
        }
    }
    private void FlipToTarget()
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

    public void Move()
    {
        float dir = 0;
        if (parameter.isFacingRight)
        {
            dir = 1f;
        }
        else
        {
            dir = -1f;
        }
        parameter.RB.linearVelocity = new Vector2(walkSpeed * dir, parameter.RB.linearVelocity.y);
    }

    public void DisableLinearVelocity()
    {
        parameter.RB.linearVelocity = Vector2.zero;
    }
}
