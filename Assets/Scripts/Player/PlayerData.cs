using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName = "Data/Player/New Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public float totalXP = 0;
    public int strength, agility, intellect, willpower, fortitude = 1;
    public PlayerMovementData movementData;

    public int skillPointsAvail = 0;

    public Dictionary<int, float> levels = new Dictionary<int, float>()
    {
        //LVL, REQXP
        {1, 100 },
        {2, 250 },
        {3, 600 }
    };

}
