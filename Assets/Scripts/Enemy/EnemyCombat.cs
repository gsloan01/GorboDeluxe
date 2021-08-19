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
            if(GameSettings.Instance.debug) Debug.Log("Targeting " + target.gameObject.name);
            timer += Time.deltaTime;
            if (timer >= data.timeBetween)
            {
                List<Damage> damages = new List<Damage>();
                
                timer = 0;
                Damageable damageable = target.GetComponent<Damageable>();
                AttackData attack = GetRandomAttack();
                for (int i = 0; i < attack.types.Count; i++)
                {
                    //creates a damage object for each type in the data... need to fix this lol
                    damages.Add(new Damage { damageType = attack.types[i], value = attack.values[i] });
                }
                target?.GetComponent<Damageable>()?.RecieveDamage(damages, gameObject);
            }
        }
        else
        {
            timer = 0;
        }

    }
}
