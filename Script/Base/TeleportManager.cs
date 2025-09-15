using System.Collections.Generic;
using UnityEngine;

/*
    Player could dynamically choose whether or not to enter door. *

    Survivors should not use door by themselves.
    
    if survivors are in follow mode and they are in different level from the player they choose which door to use.

    If zombies are after the player then they could pass the door without getting teleported.

    
*/
public class TeleportManager : MonoBehaviour
{
    public Transform destination;

    [SerializeField] private bool hasTeleported;

    public bool shouldIncrementLevelSignature;

    private HashSet<GameObject> blockedItems = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (blockedItems.Contains(other.gameObject))
        {
            return;
        }
        if (!(other.CompareTag("Zombie") || other.CompareTag("Survivor")))
        {
            return;
        }
        if (other.CompareTag("Survivor"))
        {
            SurvivorBase survivor = other.GetComponentInChildren<SurvivorBase>();
            if (survivor.isPlayedByPlayer)
            {
                return;
            }
        }
        Teleport(other.gameObject);

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        RecoverGameObject(other.gameObject);
    }

    public void BlockGameObject(GameObject obj)
    {
        blockedItems.Add(obj);
    }

    public void RecoverGameObject(GameObject obj)
    {
        blockedItems.Remove(obj);
    }

    public void Teleport(GameObject obj)
    {
        if (!ShouldTeleport(obj))
        {
            return;
        }
        obj.transform.position = destination.transform.position;

        destination.GetComponent<TeleportManager>().BlockGameObject(obj);

        EventManager.RaiseOnFloorChanged(obj, shouldIncrementLevelSignature);
    }

    public bool ShouldTeleport(GameObject obj)
    {
        return !blockedItems.Contains(obj);
    }
}
