using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attacks/AttackData")]
public class AttackData : ScriptableObject
{
    public List<Damage> damages;
}

[System.Serializable]
public struct Damage
{
    public float value;
    public dtype damageType;
    public enum dtype
    {
        Physical, Magical
    }
}

