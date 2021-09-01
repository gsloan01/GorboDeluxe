using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCombat : MonoBehaviour
{
    public GameObject target;
    public EnemyCombatData data;
    EnemyAnimatorController animatorController;
    
    float timer;

    private void Awake()
    {
        data = GetComponent<Enemy>().data.combatData;
        animatorController = GetComponent<Enemy>().animatorController;
        
    }
    AttackData GetRandomAttack()
    {
        return data.attacks[Random.Range(0, data.attacks.Count)];
    }

    public void Combat()
    {
        if(target)
        {
            if(GameSettings.Instance.debug) Debug.Log("Targeting " + target.gameObject.name);
            timer += Time.deltaTime;
            if (timer >= data.timeBetween)
            {

                
                timer = 0;

                AttackData attack = GetRandomAttack();

                target?.GetComponent<Damageable>()?.RecieveDamage(attack.damages, gameObject);
                animatorController.AttackAnim();
            }
        }
        else
        {
            timer = 0;
        }

    }
}
