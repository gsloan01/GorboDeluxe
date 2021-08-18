using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float detectionRange;
    public float aggroLossRange;
    //public DamageableData 
    public EnemyCombatData combatData;
}
