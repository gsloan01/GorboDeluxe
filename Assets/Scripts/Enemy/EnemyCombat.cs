using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCombat : MonoBehaviour
{
    EnemyCombatData data;
    float timer;

    private void Awake()
    {
        data = GetComponent<Enemy>().data.combatData;
    }

    public void Combat()
    {

    }
}
