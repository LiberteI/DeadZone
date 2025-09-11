using UnityEngine;

public class InteractionBox : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other == null)
        {
            return;
        }

        // Debug.Log($"Entered a collider {other}");
        
        if (other.CompareTag("Corpse"))
        {
            // Debug.Log($"Entered a Corpse {other.gameObject}");
            if (Input.GetKey("e"))
            {
                // Debug.Log("Looted a corpse");
                EventManager.RaiseOnLootCorpose(other.gameObject);
                return;
            }

        }
        if (other.CompareTag("Survivor"))
        {
            if (Input.GetKey("e"))
            {
                // Debug.Log("Looted a corpse");
                EventManager.RaiseOnAlterAIType(other.gameObject);
                return;
            }
            
        }
    }
}
