using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This Scriptable Object holds all information relevant to the instantiation of an enemy.
/// </summary>
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    public EnemyMovementData movementData;
    public EnemyCombatData combatData;
}
