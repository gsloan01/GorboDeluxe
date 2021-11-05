using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attacks/AttackData")]
[System.Serializable]
public class AttackData : ScriptableObject
{
    public List<Damage> damages;
}

[System.Serializable]
public struct Damage
{
    public float minBaseValue;
    public float maxBaseValue;

    public dtype damageType;
    public enum dtype
    {
        Physical, Fire, Ice, Poison, Bleed, Magical, Lightning
    }
    [Range(0,1)]
    public float critChance;
}

