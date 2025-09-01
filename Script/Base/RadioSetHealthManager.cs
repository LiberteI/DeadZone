using UnityEngine;

public class RadioSetHealthManager : MonoBehaviour
{
    public float maxHealth;

    public float curHealth;

    public bool isBroken;

    void OnEnable()
    {
        EventManager.OnMeleeHit += TakeDamage;
    }
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        TryBreaking();
    }
    void OnDisable()
    {
        EventManager.OnMeleeHit -= TakeDamage;
    }
    public void TakeDamage(MeleeHitData data)
    {
        // receiver filter
        if (this.gameObject != data.receiver)
        {
            return;
        }
        curHealth -= data.damage;
    }

    private void TryBreaking()
    {
        if (isBroken)
        {
            return;
        }

        if (curHealth <= 0)
        {
            EventManager.RaiseOnBaseBroken();
            Debug.Log("YOU LOSE");
            isBroken = true;
        }

    }
}
