using UnityEngine;

public class ZombieHealthManager : MonoBehaviour
{
    
    /*
        This script is responsible for keeping track of zombie's health status.

        The health will get deducted if damage is taken.

        If health drops to and below 0, Zombie dies instantly.
    */

    [SerializeField] private float maxHealth;

    [SerializeField] private float curHealth;

    public bool isDead;

    void OnEnable()
    {
        EventManager.OnBulletHit += TakeDamage;

        EventManager.OnMeleeHit += TakeDamage;

        EventManager.OnZombieDie += Die;
    }

    void OnDisable()
    {
        EventManager.OnBulletHit -= TakeDamage;

        EventManager.OnMeleeHit -= TakeDamage;
        
        EventManager.OnZombieDie -= Die;
    }
    void Start(){
        curHealth = maxHealth;
    }


    public void TakeDamage(BulletHitData data)
    {
        // receiver filter
        if (this.gameObject != data.receiver)
        {
            return;
        }
        curHealth -= data.damage;
        
        if (curHealth <= 0)
        {
            EventManager.RaiseOnZombieDie(data.receiver);
        }
    }

    public void TakeDamage(MeleeHitData data)
    {
        // receiver filter
        if (this.gameObject != data.receiver)
        {
            return;
        }
        curHealth -= data.damage;
        if (curHealth <= 0)
        {
            EventManager.RaiseOnZombieDie(data.receiver);
        }
    }

    private void Die(GameObject zombie)
    {
        if (zombie != this.gameObject)
        {
            return;
        }
        if (isDead)
        {
            return;
        }
        isDead = true;
    }


}
