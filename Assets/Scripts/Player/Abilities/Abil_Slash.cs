using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Data/Ability/Warrior/Slash")]
public class Abil_Slash : PlayerAbility
{
    public float range = 1.8f;
    public AttackData data;
    public GameObject FX;

    public override void Activate(Player caster)
    {
        //CREATE A UTILS CLASS
        GameObject closest = caster.GetClosestTarget(range);
        if (closest != null)
        {
            closest.GetComponent<Damageable>().RecieveDamage(data.damages, caster.gameObject);
            Debug.Log("SLASH WORKS");
            
        }
        else
        {
            if (GameSettings.Instance.debug) Debug.Log("No target in range for SLASH");
        }
    }
}
