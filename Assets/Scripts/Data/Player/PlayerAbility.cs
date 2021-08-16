using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Ability", menuName = "Data/Abilities/Player/PlayerAbility")]
public class PlayerAbility : ScriptableObject
{
    public string name;
    public abilityType type = abilityType.Attack;
    public Sprite icon;


    public float value;
    public float cooldown;


    public enum abilityType
    {
        Attack
    }

    
}
