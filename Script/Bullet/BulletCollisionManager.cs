using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

[Serializable]
public class BulletHitData{
    // receiver identifier
    public GameObject hitReceiver;
    
    public float damage;

    public Vector2 bulletFlyingDir;
}
public class BulletCollisionManager : MonoBehaviour
{   
    [SerializeField] private BulletManager manager;
    
    private BulletHitData data;

    private Vector3 lastFramePos;

    private Vector3 curFramePos;

    void Start(){
        lastFramePos = transform.position;

        data = new BulletHitData();
    }

    void FixedUpdate(){
        RayCastSweep();
    }
    private void SetData(GameObject receiver){
        if(receiver == null){
            return;
        }
        data.damage = manager.bulletDamage;

        data.bulletFlyingDir = manager.RB.linearVelocity.normalized;

        data.hitReceiver = receiver;
    }

    /*
        This collision check is not reliable enough for precise hit check.

        As a result: I will implement a ray cast sweep.

        compute last frame pos and this frame pos, and do a raycast. If there is object in between, treat it as a collision.
    */
    private void OnTriggerEnter2D(Collider2D other){
        
        if(other == null){
            return;
        }
        if(!other.CompareTag("Zombie")){
            return;
        }
        
        SetData(other.gameObject);

        EventManager.RaiseOnBulletHit(data);

        // Debug.Log($"Collider Hit {data.hitReceiver}");

        manager.DestroyBullet();
    }

    private void RayCastSweep(){
        curFramePos = transform.position;

        Vector3 direction = curFramePos - lastFramePos;

        float distance = direction.magnitude;
        
        if(distance == 0){
            lastFramePos = curFramePos;
            return;
        }


        RaycastHit2D hit = Physics2D.Raycast(lastFramePos, direction.normalized, distance);

        if(hit.collider == null){
            lastFramePos = curFramePos;
            return;
        }
        if(!hit.collider.CompareTag("Zombie")){
            lastFramePos = curFramePos;
            return;
        }
        SetData(hit.collider.gameObject);

        EventManager.RaiseOnBulletHit(data);

        // Debug.Log($"Raycast Hit {data.hitReceiver}");

        manager.DestroyBullet();

        lastFramePos = curFramePos;
    }
}
