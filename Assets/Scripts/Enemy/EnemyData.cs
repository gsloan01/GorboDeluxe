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

    public float bodyLifetime = 3.0f;
    public float xpDropped = 5.0f;
    public float detectionRange = 8.0f;
    public float aggroLossRange = 15.0f;
    public float moveSpeed;

    public float attackCooldown = 0.8f;
    public bool wanders;
    public float wanderFrequency = 2.0f;
    public float wanderDistance = 5.0f;
}
