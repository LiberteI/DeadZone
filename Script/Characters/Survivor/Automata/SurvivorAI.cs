using UnityEngine;
/*
    Automatic Survivor can follow or hold position
*/

public enum AIMode
{
    Follow,

    HoldPosition
}
public class SurvivorAI : MonoBehaviour
{
    [Header("distance > 0 : target is to the right")]
    public float distance;

    public bool shouldFollow;

    [SerializeField] private float distanceThreshold;

    [SerializeField] private AIMode curAIMode;

    [SerializeField] private SurvivorManager survivorManager;
    void Update()
    {
        CalculateDistanceToTarget();

        DecideShouldFollow();
    }
    

    private void CalculateDistanceToTarget()
    {
        // calculate distance on the x axis
        if (survivorManager.survivorIsPlayed == null)
        {
            Debug.Log("current survivor played is null");
            return;
        }
        // cache Transform
        Transform target = survivorManager.survivorIsPlayed.GetComponentInChildren<Rigidbody2D>().transform;

        float curDistance = target.transform.position.x - transform.position.x;

        distance = curDistance;
    }

    private void DecideShouldFollow()
    {
        if (Mathf.Abs(distance) > distanceThreshold)
        {
            shouldFollow = true;
        }
        else
        {
            shouldFollow = false;
        }
    }
}
