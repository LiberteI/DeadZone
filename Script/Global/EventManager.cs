using UnityEngine;
using System;
public static class EventManager
{
    public static event Action<BulletHitData> OnBulletHit;

    public static event Action<MeleeHitData> OnMeleeHit;

    public static event Action<GameObject> OnSurvivorDied;

    public static event Action OnBaseBroken;

    public static void RaiseOnBulletHit(BulletHitData data)
    {
        if (OnBulletHit != null)
        {
            OnBulletHit(data);
        }
    }

    public static void RaiseOnMeleeHit(MeleeHitData data)
    {
        if (OnMeleeHit != null)
        {
            OnMeleeHit(data);
        }
    }

    public static void RaiseOnSurvivorDied(GameObject survivor)
    {
        if (OnSurvivorDied != null)
        {
            OnSurvivorDied(survivor);
        }
    }

    public static void RaiseOnBaseBroken()
    {
        if (OnBaseBroken != null)
        {
            OnBaseBroken();
        }
    }
    
}
