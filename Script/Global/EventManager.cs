using UnityEngine;
using System;
public static class EventManager
{
    public static event Action<BulletHitData> OnBulletHit;

    public static void RaiseBulletHit(BulletHitData data){
        if(OnBulletHit != null){
            OnBulletHit(data);
        }
    }
}
