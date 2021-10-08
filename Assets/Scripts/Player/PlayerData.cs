using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName = "Data/Player/New Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int strength, agility, intellect, willpower, fortitude;
    public PlayerMovementData movementData;
}
