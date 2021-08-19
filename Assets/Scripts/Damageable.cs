using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Health health;
    Dictionary<Damage.dtype, float> damageMods = new Dictionary<Damage.dtype, float>();
    float healingMod = 1;
    public bool allowHealingFromNegativeDamage = false;
    public bool isDead { get { return health.isDead; } }

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    /// <summary>
    /// Call this method to deal damage to a damagable entity
    /// </summary>
    /// <param name="damages">List of all damage properties</param>
    public void RecieveDamage(List<Damage> damages, GameObject source)
    {
        //total damage from this full attack
        float final = 0;
        //go through every damage source
        foreach (Damage d in damages)
        {
            final += damageMods.Count > 0 ?  (damageMods.TryGetValue(d.damageType, out float mod) ? d.value /* mod */ : d.value)  : d.value;
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
        if (GameSettings.Instance.debug) Debug.Log($"{gameObject.name} taking {final} damage from {source.name}");
        health.Apply(-final);
    }

    public void RecieveHealing(float healingValue)
    {
        health.Apply(healingValue * healingMod);
    }

}
