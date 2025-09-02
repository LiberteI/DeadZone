using UnityEngine;

[CreateAssetMenu(fileName = "DayConfig", menuName = "Game/Day Config")]
public class DayConfig : ScriptableObject
{
    public float duration;

    public int zombieCount;
}
