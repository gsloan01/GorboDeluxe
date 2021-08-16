using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Current { get { return current; } }
    float current;
    public float max = 100;

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
        current += change;

        if(GameSettings.Instance.debug)
        {
            string debuglog;
            debuglog = (change >= 0) ? (gameObject.name + " healed by " + change + " !") : (gameObject.name + " lost " + change + " health!");
            Debug.Log(debuglog);
        }

        
    }

}
