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
        Instantiate(arrow, new Vector3(caster.transform.position.x, caster.transform.position.y + 0.1f, caster.transform.position.z), Quaternion.identity);
    }
}
