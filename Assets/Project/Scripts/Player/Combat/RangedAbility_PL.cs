using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRangedAbility", menuName = "Data/Player/Attacks/RangedAttack")]
public class RangedAbility_PL : PlayerAbility
{
    [SerializeField] Projectile projectile;
    public override void Cast(Player caster)
    {
        if (!onCooldown && caster.HasResource(cost))
        {
            //PlayAnim()
            //Spawn FX
            caster.animController.SetRanged1();
            Projectile spawned = Instantiate(projectile, caster.transform.position + Vector3.up * 0.5f, caster.transform.rotation);
            spawned.Set();
            
            caster.OnPlayerResourceChange.Invoke(-cost);
            cooldownTimer = 0;
            onCooldown = true;

        }
    }
}
