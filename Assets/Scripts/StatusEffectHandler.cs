using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusEffectHandler : MonoBehaviour
{
    public List<StatusEffect> activeEffects;
    public Health health;
    public MobilityStatusEffect test;
    private void Awake()
    {
        activeEffects = new List<StatusEffect>();
        
        
    }

    private void Start()
    {
        StartCoroutine(StartMobilityStatusEffect(test));

    }

    IEnumerator StartDamageStatusEffect(DamageStatusEffect effect)
    {
        bool active = true;
        float timer = 0;
        Debug.Log("Damage status effect started");
        
        while(active)
        {
            timer += 1 / effect.ticksPerSecond;
            if (timer >= effect.duration) active = false;
            //Spawn FX when damage is taken
            //Instantiate(fx, health.gameobject.transform);
            yield return new WaitForSeconds(1 / effect.ticksPerSecond);
            health.Apply(effect.damage);
            Debug.Log("Damage status effect dealt damage");
        }
        Debug.Log("Damage effect over");
        yield return null;
    }

    IEnumerator StartMobilityStatusEffect(MobilityStatusEffect effect)
    {
        bool active = true;
        float timer = 0;
        
        //Start Status Effect
        if (effect.speedMultiplier == 0) effect.speedMultiplier = 0.0001f;
        if(health.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            //give it the multiplier
            movement.speedMultiplier *= effect.speedMultiplier;
            while (active)
            {
                timer += Time.deltaTime;
                if (timer >= effect.duration) active = false;
            }
            //cancel out the multiplier
            movement.speedMultiplier /= effect.speedMultiplier;
        }
        else
        {
            health.GetComponent<Enemy>();
            while (active)
            {
                timer += Time.deltaTime;
                if (timer >= effect.duration) active = false;
            }
        }

        //End Status Effect
        yield return null;
        
    }
}

[System.Serializable]
public abstract class StatusEffect
{
    public float duration = 5;
}

[System.Serializable]
public class DamageStatusEffect : StatusEffect
{

    public string source;
    public float ticksPerSecond = 2;
    public AttackData damage;
    public GameObject fx;
}

[System.Serializable]
public class MobilityStatusEffect : StatusEffect
{
    public enum MobilityEffect
    {
        SpeedChange, Stop
    }
    public MobilityEffect mobilityEffect;

    public float speedMultiplier = 1;

}





