using UnityEngine;

public class ZombieMovementMnager : MonoBehaviour
{
    [SerializeField] private BaseZombie zombie;

    public BaseZombieParameter parameter;

    void Start(){
        parameter = zombie.parameter;
    }
    void Update(){
        DefineFacingDir();
    }

    private void DefineFacingDir(){
        if(transform.eulerAngles.y == 0){
            parameter.isFacingRight = true;
            return;
        }
        if(transform.eulerAngles.y == 180f){
            parameter.isFacingRight = false;
            return;
        }
    }
}
