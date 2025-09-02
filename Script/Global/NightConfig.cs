using UnityEngine;

/*  
    This script is responsible for keeping night configs.
*/
[CreateAssetMenu(fileName = "NightConfig", menuName = "Game/Night Config")]
public class NightConfig : ScriptableObject
{
    public int nightNum;

    public int zombieCount;

    public float duration;

}
