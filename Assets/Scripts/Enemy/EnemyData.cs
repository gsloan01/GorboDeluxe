using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    public EnemyMovementData movementData;
    public EnemyCombatData combatData;
}
