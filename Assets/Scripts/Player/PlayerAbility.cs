using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Data/Ability")]
public abstract class PlayerAbility : ScriptableObject
{
    public string abilName;
    public string description;
    public float cost;
    public float cooldown;

    public abstract void Activate(Player caster);
}
