using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        //max = base + scaling
        current = max;
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

            if (GameSettings.Instance.debug)
            {
                string debuglog;
                debuglog = (change >= 0) ? (gameObject.name + " healed by " + change + " !") : (gameObject.name + " lost " + change + " health! Bringing them to " + current +  ".");
                Debug.Log(debuglog);
            }
            if (current <= 0)
            {
                isDead = true;
            }

        }
    }

}
