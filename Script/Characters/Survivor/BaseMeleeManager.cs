using UnityEngine;

public class BaseMeleeManager : MonoBehaviour
{
    [SerializeField] SurvivorBase survivor;

    private SurvivorParameters parameter;

    [SerializeField] private MeleeHitBoxManager hitboxManager;

    [SerializeField] private float damage;

    void Start(){
        parameter = survivor.parameter;
    }
    void Update(){
        SetData();
    }

    private void SetData(){
        if(parameter.isFacingRight){
            hitboxManager.SetData(damage, transform.right);
        }
        else{
            hitboxManager.SetData(damage, -transform.right);
        }
    }
}
