using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Health health;
    Dictionary<Damage.dtype, float> damageMods;
    float healingMod = 1;
    public bool allowHealingFromNegativeDamage = false;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    /// <summary>
    /// Call this method to deal damage to a damagable entity
    /// </summary>
    /// <param name="damages">List of all damage properties</param>
    public void RecieveDamage(List<Damage> damages)
    {
        //total damage from this full attack
        float final = 0;
        //go through every damage source
        foreach (Damage d in damages)
        {
            final += damageMods.TryGetValue(d.damageType, out float mod) ? d.value * mod : d.value ;
            //if there is a damage modifier
            //then multiply the incoming damage by the modifier
            //otherwise, add the full damage
            
        }
        //if we dont allow healing from negative...
        if(!allowHealingFromNegativeDamage)
        {
            //then if the final damage is negative, set it to zero
            if (final <= 0) final = 0;
        }
        //finally apply all damage
        health.Apply(-final);
    }

    public void RecieveHealing(float healingValue)
    {
        health.Apply(healingValue * healingMod);
    }

}
