using UnityEngine;

public class SWATShootingManager : BaseShootingManager
{
    private SWAT swat;

    private SWATParameter swatParameter;

    void Start()
    {
        swat = (SWAT)base.survivor;

        swatParameter = swat.parameter;
    }

    
    /*
        There should be 3 partterns of shooting:
        Pistol for shield operator, AR for assaulter, shotgun for breacher.
        Decide shooting patterns based on their roles.
    */
}
