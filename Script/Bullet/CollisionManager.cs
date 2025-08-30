using UnityEngine;

public class CollisionManager : MonoBehaviour
{   
    [SerializeField] BulletManager manager;
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other != null){
            Debug.Log("Hit a stuff");
            manager.DestroyBullet();
        }
    }
}
