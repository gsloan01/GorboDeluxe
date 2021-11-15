using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] bool tracking;
    [SerializeField] bool piercing;
    [SerializeField] int pierces;
    [SerializeField] float lifetime;
    [SerializeField] float speed;
    [SerializeField] bool destroyOnEnviron;
    [SerializeField] AttackData data;

    [SerializeField] ProjectilePath pathing;
    [SerializeField] List<DamageStatusEffect> damageEffectsGiven;
    public enum ProjectilePath
    {
        Straight, SinWave, Random, Targeted
    }



    List<Health> targets;
    public void Set(List<Health> potentialTargets = null)
    {
        Destroy(gameObject, lifetime);
        targets = potentialTargets;


    }
    private void Update()
    {
        switch (pathing)
        {
            case ProjectilePath.Straight:
                transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * speed);
                break;
            case ProjectilePath.SinWave:
                break;
            case ProjectilePath.Random:
                break;
            case ProjectilePath.Targeted:
                break;
            default:
                break;
        }
        if(tracking)
        {
            Health target = Utility.GetNearestInList<Health>(transform.position, targets);
            transform.rotation = Utility.FaceTarget(target.gameObject, transform);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            if(other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                //create hurtFX and sound
                enemy.HealthCPNT.Apply(data);
                if (enemy.TryGetComponent<StatusEffectHandler>(out StatusEffectHandler handler)) handler.ApplyDamageEffects(damageEffectsGiven);
                if (piercing)
                {
                    pierces--;
                    OnCollide(pierces == 0);
                }
                else
                {
                    OnCollide(piercing);
                }
                
                
                
            }
            OnCollide(destroyOnEnviron);
        }

    }
    private void OnCollide(bool destroy)
    {
        if(destroy) Destroy(gameObject);
    }

}
