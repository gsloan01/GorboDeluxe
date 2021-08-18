using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatData", menuName = "Data/Enemies/CombatData")]
public class EnemyCombatData : ScriptableObject
{
    public List<AttackData> attacks;
    public float timeBetween;

    public bool stayAtRange;
    public bool flee;
    public float stayAwayRange;
}
