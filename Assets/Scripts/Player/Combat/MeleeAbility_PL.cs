using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttack_Player", menuName = "Data/Player/Attacks/MeleeAttack")]
public class MeleeAbility_PL : PlayerAbility
{
    public AttackData data;
    [SerializeField] float radius = 3.0f;
    [SerializeField] float angleOfAttack = 90.0f;

    public override void Cast(Player caster)
    {
        if(!onCooldown && caster.HasResource(cost))
        {
            //PlayAnim()
            //Spawn FX
            List<Health> valid = new List<Health>();
            foreach (var v in Physics.OverlapSphere(caster.centerMassTransform.position, radius))
            {
                
                float angle = Vector3.Angle(caster.gameObject.transform.forward, v.transform.position - caster.transform.position);
                if(v.CompareTag("Enemy"))Debug.Log("Angle from forward to enemy is " + angle);
                if (v.CompareTag("Enemy") && ((angle <= angleOfAttack) || (angle >= (360 - angleOfAttack) || angle == 0)))
                {
                    
                    valid.Add(v.GetComponent<Health>());
                }
            }
            if (valid.Count > 0)
            {
                Health closest = Utility.GetNearestInList<Health>(caster.centerMassTransform.position, valid);
                closest.Apply(data);
                //Debug.Log($"{closest.name}'s health is {closest.Current} / {closest.max}");
            }
            caster.OnPlayerResourceChange.Invoke(-cost);
            cooldownTimer = 0;
            onCooldown = true;
            
        }
        else
        {
            
        }
        
    }
}
