using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBuff", menuName = "Data/Ability/WeaponBuff")]
public class Abil_WeaponBuff : PlayerAbility
{
    public GameObject weaponBuff;
    public GameObject buffStartFX;
    public override void Activate(Player caster, List<Damage> buffs = null)
    {
        //Create the weaponBuff on the players weapon
        if (buffStartFX != null) Instantiate(buffStartFX, caster.weaponTransforms);
        GameObject newBuff = Instantiate(weaponBuff, caster.weaponTransforms);
        caster.AddWeaponBuff(newBuff);
    }
}
