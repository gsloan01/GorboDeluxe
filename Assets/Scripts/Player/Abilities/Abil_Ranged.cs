using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAbilityData", menuName = "Data/Ability/RangedAbility")]
public class Abil_Ranged : PlayerAbility
{

    public GameObject projectile;

    public override void Activate(Player caster)
    {
        //create the arrow in front of the player
        Vector3 spawnLocation = caster.transform.position + caster.transform.forward;
        Vector3 newLocation = new Vector3(spawnLocation.x, spawnLocation.y + .5f, spawnLocation.z);
        Instantiate(projectile, newLocation, Quaternion.LookRotation(caster.transform.forward, caster.transform.up));
    }
}
