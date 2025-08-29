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
        GameObject curBullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        Rigidbody2D curBulletRB = curBullet.GetComponentInChildren<Rigidbody2D>();

        if(curBulletRB == null){
            Debug.Log("curBullet RB is null");
            yield break;
        }
        if(parameter.isFacingRight){
            curBullet.transform.rotation = Quaternion.Euler(0, 0, -90f);
            // assign force

            curBulletRB.AddForce(new Vector2(bulletFlyForce, 0), ForceMode2D.Impulse);
        }
        else{
            curBullet.transform.rotation = Quaternion.Euler(0, -180f, -90f);
            
            // assign force

            curBulletRB.AddForce(new Vector2(-1f * bulletFlyForce, 0), ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(firingInterval);
        firing = null;
    }
}
