using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Data/Ability/Warrior/Slash")]
public class Abil_Arrow : PlayerAbility
{

    public GameObject arrow;

    public override void Activate(Player caster)
    {
        //create the arrow in front of the player
        Instantiate(arrow, caster.transform.position + caster.transform.forward, Quaternion.LookRotation(caster.transform.forward, caster.transform.up));
    }
}
