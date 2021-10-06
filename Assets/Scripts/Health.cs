using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Current { get { return current; } }
    public float max = 100;
    float current;

    public bool isDead = false;

    private void Start()
    {
        current = max;
    }

    /// <summary>
    /// Apply a change to health
    /// </summary>
    /// <param name="change"> Amount to change health by.</param>
    public void Apply(float change)
    {
        if (current <= 0)
        {
            isDead = true;
        }
        if (!isDead)
        {
            current += change;

            if (GameSettings.Instance.debug)
            {
                string debuglog;
                debuglog = (change >= 0) ? (gameObject.name + " healed by " + change + " !") : (gameObject.name + " lost " + change + " health! Bringing them to " + current +  ".");
                Debug.Log(debuglog);
            }


        }
    }

}
