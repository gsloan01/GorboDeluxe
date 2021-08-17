using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attacks/AttackData")]
public class EnemyData : ScriptableObject
{
    public float detectionRange;
    public float aggroLossRange;
    //public DamageableData 
    public EnemyCombatData combatData;
}
