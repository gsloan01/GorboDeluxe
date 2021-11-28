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
    public bool invuln = false;
    [SerializeField] AudioClip hurtSFX, deathSFX;

    //should make this an ondeath unity event that the player or enemy will subscribe to
    public bool isDead = false;
    public UnityEvent OnDeath;
    public UnityEvent OnHealed;
    public UnityEvent OnHurt;

    private void Awake()
    {
        current = max;
        OnHurt.AddListener(HurtSound);
        OnDeath.AddListener(DeathSound);
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
                isDead = true;
                OnDeath.Invoke();
            }

        }
    }

    public void Apply(AttackData data)
    {
        foreach(var v in data.damages)
        {
            bool crit = (Random.Range(0f, 1f)< v.critChance);
            Debug.Log(v.critChance.ToString());
            float damage = Random.Range(-v.maxBaseValue, -v.minBaseValue) * (crit ?  2 : 1);
            Apply(damage);
            DamageNumberManager.Instance.SpawnNumber(Mathf.RoundToInt(damage), crit, transform);
            if(crit) CinemachineShake.Instance.Shake(2, .5f, .1f, .1f);
        }
    }

    public void ChangeMax(float newMax, bool regenToMax = true)
    {
        max = newMax;
        if(regenToMax) current = max;
    }

    public void HurtSound()
    {
        if (hurtSFX != null) SFXManager.Instance.PlaySFX(hurtSFX, transform);
    }
    public void DeathSound()
    {
        if (deathSFX != null) SFXManager.Instance.PlaySFX(deathSFX, transform, false);
    }
}
