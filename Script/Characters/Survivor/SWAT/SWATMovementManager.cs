using UnityEngine;

public class SWATMovementManager : BaseMovementManager
{
    private SWAT swat;

    private SWATParameter swatParameter;

    void Awake(){
        swat = (SWAT)base.survivor;

        swatParameter = swat.parameter;
    }

    public override bool CanJump(){
        if(!swatParameter.isPlayedByPlayer){
            return false;
        }
        if(swatParameter.isShooting){
            return false;
        }

        if(swatParameter.isDoingMelee){
            return false;
        }

        if(swatParameter.isReloading){
            return false;
        }

        if(swatParameter.isCrouching){
            return false;
        }
        
        return true;
    }

    protected override bool CanMove(){
        if(!swatParameter.isPlayedByPlayer){
            return false;
        }
        if(swatParameter.isShooting){
            return false;
        }
        if(swatParameter.isDoingMelee){
            return false;
        }

        if(swatParameter.isReloading){
            return false;
        }
        if(swatParameter.isCrouching){
            return false;
        }
        return true;
    }

    protected override bool CanFlip(){
        if(!swatParameter.isPlayedByPlayer){
            return false;
        }
        if(swatParameter.isShooting){
            return false;
        }

        if(swatParameter.isReloading){
            return false;
        }  
        return true;
    }
}
