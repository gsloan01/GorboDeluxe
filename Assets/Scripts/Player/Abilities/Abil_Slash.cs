using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Data/Ability/Warrior/Slash")]
public class Abil_Slash : PlayerAbility
{
    public float range = 1.8f;
    public AttackData data;
    public GameObject SwipeFX;
    public GameObject HitEnemyFX;

    
    public override void Activate(Player caster, List<Damage> buffs = null)
    {
        //CREATE A UTILS CLASS
        Vector3 spawnLocation = caster.transform.position + caster.transform.forward;
        Vector3 newLocation = new Vector3(spawnLocation.x, spawnLocation.y + .5f, spawnLocation.z);
        Instantiate(SwipeFX, newLocation, Quaternion.LookRotation(caster.transform.forward, caster.transform.up));
        GameObject closest = caster.GetClosestTarget(range);
        if (closest != null)
        {
            List<Damage> all = new List<Damage>(data.damages);
            if(buffs != null)
            {
                if (buffs.Count > 0)
                {
                    foreach (Damage d in buffs)
                    {
                        all.Add(d);
                    }
                }
            }

            
            closest.GetComponent<Damageable>().RecieveDamage(all, caster.gameObject);
            Debug.Log("SLASH WORKS");
            Instantiate(HitEnemyFX, closest.transform.position + Vector3.up * .25f, Quaternion.LookRotation(caster.transform.forward, caster.transform.up), closest.transform);
        }
        else
        {
            if (GameSettings.Instance.debug) Debug.Log("No target in range for SLASH");
        }
    }
}
