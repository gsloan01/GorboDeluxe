using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float baseHP = 100;
    public float scalingValue;
    float healingMod = 1;
    public bool allowHealingFromNegativeDamage = false;
    Dictionary<Damage.dtype, float> damageMods = new Dictionary<Damage.dtype, float>();
    public float Current { get { return current; } }
    float current;
    public float max = 100;

    //should make this an ondeath unity event that the player or enemy will subscribe to
    public bool isDead = false;
    public UnityEvent OnDeath;
    public UnityEvent OnHealed;
    public UnityEvent OnHurt;

    private void Awake()
    {
        current = max;
    }
    private void Start()
    {
        //max = base + scaling
        //current = max;
    }

    /// <summary>
    /// Apply a change to health
    /// </summary>
    /// <param name="change"> Amount to change health by.</param>
    public void Apply(float change)
    {

        if (!isDead)
        {
            current += change;
            if (change > 0) OnHealed.Invoke();
            else OnHurt.Invoke();
            
            if (GameSettings.Instance.debug)
            {
                string debuglog;
                debuglog = (change >= 0) ? (gameObject.name + " healed by " + change + " !") : (gameObject.name + " lost " + change + " health! Bringing them to " + current +  ".");
                //Debug.Log(debuglog);
                
            }
            if (current <= 0)
            {
                OnDeath.Invoke();
            }

        }
    }

    public void Apply(AttackData data)
    {
        foreach(var v in data.damages)
        {
            Apply(-v.minBaseValue);
        }
    }

}
