using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BaseShootingManager : MonoBehaviour
{
    /*
        This script is responsible for shooting, 
            including generating bullets, 
            managing reload etc.
    */
    [SerializeField] protected SurvivorBase survivor;

    protected SurvivorParameters parameter;

    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected float firingInterval; // 0 - 1

    private Coroutine firing;

    void Awake(){
        this.parameter = survivor.parameter;
    }

    public virtual void FireABullet(Transform muzzle){
        if(firing != null){
            return;
        }
        if(bulletPrefab == null){
            Debug.Log("Bullet prefab is not assigned");
            return;
        }
        // if get called, start a coroutine
        firing = StartCoroutine(ExecuteFireABullet(muzzle));
    }

    private IEnumerator ExecuteFireABullet(Transform muzzle){
        // instantiate new bullet
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        BulletManager curBullet = bullet.GetComponent<BulletManager>();

        BulletCollisionManager curBulletCollider = bullet.GetComponentInChildren<BulletCollisionManager>();
        
        curBulletCollider.SetBulletInitiator(this.gameObject);

        if (curBullet == null)
        {
            Debug.Log("curBullet is null");
            yield break;
        }
        // determine bullet dir
        if (parameter == null)
        {
            Debug.Log("parameter is null");
            yield break;
        }
        curBullet.isFacingRight = parameter.isFacingRight;

        bullet.SetActive(true);
        yield return new WaitForSeconds(firingInterval);
        firing = null;
    }
}
