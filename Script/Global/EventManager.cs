using UnityEngine;
using System;
using Unity.VisualScripting;
public static class EventManager
{
    public static event Action<BulletHitData> OnBulletHit;

    public static event Action<MeleeHitData> OnMeleeHit;

    public static event Action<GameObject> OnSurvivorDied;

    public static event Action OnBaseBroken;

    public static event Action<DayConfig> OnBreakingDawn;

    public static event Action<NightConfig> OnNightFall;

    public static event Action OnStopSpawning;

    public static event Action<GameObject> OnZombieDie;

    public static event Action OnClearLevel;

    public static event Action<ClutchData> OnClutch;

    public static event Action<ClutchData> OnRelease;

    public static event Action<ProvocationData> OnProvoked;

    public static event Action<GameObject> OnScream;

    public static event Action<GameObject> OnIsWithinScreamRange;

    public static event Action<DetectionData> OnSeeSurvivor;

    public static event Action<DetectionData> OnControlSuccessful;

    public static event Action<GameObject> OnLootCorpse;

    public static event Action<DetectionData> OnSeeZombie;

    
    public static void RaiseOnSeeZombie(DetectionData data)
    {
        if (OnSeeZombie != null)
        {
            OnSeeZombie(data);
        }
    }

    public static void RaiseOnLootCorpose(GameObject zombie)
    {
        if (OnLootCorpse != null)
        {
            OnLootCorpse(zombie);
        }
    }

    public static void RaiseOnControlSuccessful(DetectionData data)
    {
        if (OnControlSuccessful != null)
        {
            OnControlSuccessful(data);
        }
    }

    public static void RaiseOnSeeSurvivor(DetectionData data)
    {
        if (OnSeeSurvivor != null)
        {
            OnSeeSurvivor(data);
        }
    }

    public static void RaiseOnIsWithinScreamRange(GameObject receiver)
    {
        if (OnIsWithinScreamRange != null)
        {
            OnIsWithinScreamRange(receiver);
        }
    }

    public static void RaiseOnScream(GameObject screamer)
    {
        if (OnScream != null)
        {
            OnScream(screamer);
        }
    }

    public static void RaiseOnProvoked(ProvocationData data)
    {
        if (OnProvoked != null)
        {
            OnProvoked(data);
        }
    }

    public static void RaiseOnRelease(ClutchData data)
    {
        if (OnRelease != null)
        {
            OnRelease(data);
        }
    }

    public static void RaiseOnClutch(ClutchData data)
    {
        if (OnClutch != null)
        {
            OnClutch(data);
        }
    }

    public static void RaiseOnClearLevel()
    {
        if (OnClearLevel != null)
        {
            OnClearLevel();
        }
    }

    public static void RaiseOnZombieDie(GameObject zombie)
    {
        if (OnZombieDie != null)
        {
            OnZombieDie(zombie);
        }
    }
    public static void RaiseStopSpawning()
    {
        if (OnStopSpawning != null)
        {
            OnStopSpawning();
        }
    }

    public static void RaiseOnNightFall(NightConfig curNight)
    {
        if (OnNightFall != null)
        {
            OnNightFall(curNight);
        }
    }
    public static void RaiseOnBreakingDawn(DayConfig dayConfig)
    {
        if (OnBreakingDawn != null)
        {
            OnBreakingDawn(dayConfig);
        }
    }
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
