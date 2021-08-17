using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attacks/AttackData")]
public class EnemyCombatData : ScriptableObject
{
    public List<AttackData> attacks;
    public float timeBetween;

    bool stayAtRange;
    float stayAwayRange;
}
