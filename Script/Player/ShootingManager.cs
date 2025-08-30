using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShootingManager : MonoBehaviour
{
    /*
        This script is responsible for shooting, 
            including generating bullets, 
            managing reload etc.
    */
    [SerializeField] private Player player;

    private Parameters parameter;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float firingInterval; // 0 - 1

    [SerializeField] private float bulletFlyForce;

    private Coroutine firing;

    void Start(){
        this.parameter = player.parameter;
    }

    public void FireABullet(Transform muzzle){
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

        if(curBullet == null){
            Debug.Log("curBullet is null");
            yield break;
        }
        // determine bullet dir
        curBullet.isFacingRight = parameter.isFacingRight;

        bullet.SetActive(true);
        yield return new WaitForSeconds(firingInterval);
        firing = null;
    }
}
