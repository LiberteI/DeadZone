using UnityEngine;
using System;
public static class EventManager
{
    public static event Action<BulletHitData> OnBulletHit;

    public static event Action<MeleeHitData> OnMeleeHit;

    public static void RaiseBulletHit(BulletHitData data){
        if(OnBulletHit != null){
            OnBulletHit(data);
        }
    }

    public static void RaiseOnMeleeHit(MeleeHitData data){
        if(OnMeleeHit != null){
            OnMeleeHit(data);
        }
    }
}
