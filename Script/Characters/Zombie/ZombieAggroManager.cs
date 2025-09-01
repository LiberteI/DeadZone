using UnityEngine;

/*
    Default target = nearest valid target (player-controlled ally, AI ally, or base). *

    Retarget every ~2s (throttled scan). *

    OnHit override: if the zombie is damaged, force target = attacker for a short “stickiness” window (e.g., 3–5s).*

    Base priority: if no living allies in range, or if it’s in “siege mode,”(20% is in siege mode by default) go for base. *

    Leash: don’t chase too far from spawn (prevents kiting exploits).
*/
public class ZombieAggroManager : MonoBehaviour
{

    [SerializeField] BaseZombie zombie;

    [SerializeField] BaseZombieParameter parameter;

    public GameObject currentTarget;

    [SerializeField] private float maxAggroSwitchTimer = 2f;

    [SerializeField] private float curAggroSwitchTimer;

    [SerializeField] private float maxForceAggroTimer = 5f;

    [SerializeField] private float curForceAggroTimer;

    // fixed target on the base
    public bool isInSiegeMode;

    void OnEnable()
    {
        EventManager.OnBulletHit += ForceSwitchAggro;

        EventManager.OnMeleeHit += ForceSwitchAggro;
    }

    void OnDisable()
    {
        EventManager.OnBulletHit -= ForceSwitchAggro;

        EventManager.OnMeleeHit -= ForceSwitchAggro;
    }
    void Update()
    {
        if (isInSiegeMode)
        {
            return;
        }
        TryAssignAggroTarget();

        UpdateAggroSwitchTimer();

        UpdateForceAggroTimer();
    }

    void Start()
    {
        DecideSiegeMode();
        
        if (isInSiegeMode)
        {
            return;
        }

        parameter = zombie.parameter;

        TryAssignAggroTarget();
    }


    private void UpdateAggroSwitchTimer()
    {
        if (curAggroSwitchTimer > 0)
        {
            curAggroSwitchTimer -= Time.deltaTime;
        }
    }

    private void UpdateForceAggroTimer()
    {
        if (curForceAggroTimer > 0)
        {
            curForceAggroTimer -= Time.deltaTime;
        }
    }

    private void TryAssignAggroTarget()
    {
        if (curForceAggroTimer > 0)
        {
            return;
        }

        if (curAggroSwitchTimer > 0)
        {
            return;
        }

        currentTarget = FindTheNearestTarget();

        curAggroSwitchTimer = maxAggroSwitchTimer;
    }
    // this method is called every 2 seconds
    private GameObject FindTheNearestTarget()
    {
        float minDistance = float.PositiveInfinity;

        int survivorTargetIdx = -99;

        // do square root magnitude for better performance
        float zombieToBaseDist = (RadioSetHealthManager.baseObj.transform.position - transform.position).sqrMagnitude;
        
        if (SurvivorManager.survivorList == null)
        {
            Debug.Log("survivor list not found");
            return null;
        }
        for (int i = 0; i < SurvivorManager.survivorList.Count; i++)
        {
            float curDistance = (transform.position - SurvivorManager.survivorList[i].transform.position).sqrMagnitude;

            if (curDistance < minDistance)
            {
                minDistance = curDistance;

                survivorTargetIdx = i;
            }
        }
        if (minDistance == float.PositiveInfinity || survivorTargetIdx == -99)
        {
            Debug.Log("survivor is not found");
            return RadioSetHealthManager.baseObj;
        }
        if (minDistance >= zombieToBaseDist)
        {
            return RadioSetHealthManager.baseObj;
        }
        else
        {
            return SurvivorManager.survivorList[survivorTargetIdx];
        }
    }

    private void ForceSwitchAggro(BulletHitData data)
    {
        if (data.receiver != this.gameObject)
        {
            return;
        }

        currentTarget = data.initiator;

        curForceAggroTimer = maxForceAggroTimer;
    }

    private void ForceSwitchAggro(MeleeHitData data)
    {
        if (data.receiver != this.gameObject)
        {
            return;
        }

        currentTarget = data.initiator;

        curForceAggroTimer = maxForceAggroTimer;
    }

    private void DecideSiegeMode()
    {
        float random = UnityEngine.Random.Range(0, 100);

        if (random > 80f)
        {
            isInSiegeMode = true;

            currentTarget = RadioSetHealthManager.baseObj;
        }
        else
        {
            isInSiegeMode = false;
        }
    }
}
