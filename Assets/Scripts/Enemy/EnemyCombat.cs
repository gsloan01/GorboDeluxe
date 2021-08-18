using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCombat : MonoBehaviour
{
    public GameObject target;
    public EnemyCombatData data;
    
    float timer;

    private void Awake()
    {
        data = GetComponent<Enemy>().data.combatData;
    }
    AttackData GetRandomAttack()
    {
        return data.attacks[Random.Range(0, data.attacks.Count)];
    }

    public void Combat()
    {
        if(target)
        {
            timer += Time.deltaTime;
            if (timer >= data.timeBetween)
            {
                timer = 0;
                target.GetComponent<Damageable>().RecieveDamage(GetRandomAttack().damages);
            }
        }
        else
        {
            timer = 0;
        }

    }
}
