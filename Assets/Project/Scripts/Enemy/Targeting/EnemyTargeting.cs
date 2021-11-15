using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyTargeting : MonoBehaviour
{
    /// <summary>
    /// This event is invoked when an enemy finds a target.
    /// </summary>
    public UnityEvent<GameObject> OnTargetFound_Enemy;
    protected GameObject currentTarget;
    protected Dictionary<GameObject, float> threatAnalysis;
    public abstract void Search(float range);
}
