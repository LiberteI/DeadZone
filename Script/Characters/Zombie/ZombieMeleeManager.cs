using UnityEngine;

public class ZombieMeleeManager : MonoBehaviour
{
    [SerializeField] private BaseZombie zombie;
    
    private BaseZombieParameter parameter;

    [SerializeField] private float damage;

    [SerializeField] private MeleeHitBoxManager hitboxManager;

    [SerializeField] private Transform rangeCentre;

    [SerializeField] private float rangeRadius;

    [SerializeField] private LayerMask targetLayer;


    void Start(){
        parameter = zombie.parameter;
    }
    void Update(){
        SetData();
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeCentre.position, rangeRadius);
    }

    private void SetData(){
        if(parameter.isFacingRight){
            hitboxManager.SetData(damage, transform.right);
        }
        else{
            hitboxManager.SetData(damage, -transform.right);
        }
    }

    public bool SurvivorIsInRange(){
        return Physics2D.OverlapCircle(rangeCentre.position, rangeRadius, targetLayer);
    }
}
