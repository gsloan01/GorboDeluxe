using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerAbility : ScriptableObject
{
    [Header("Identification")]
    public Sprite icon;
    /// <summary>
    /// Name of the ability.
    /// </summary>
    public string abilName;

    [TextArea(1, 5)]
    /// <summary>
    /// Short description of the ability.
    /// </summary>
    public string desc;


    [Space(10)]
    [Header("Info")]
    /// <summary>
    /// Resource cost of the ability. Negative will give resource.
    /// </summary>
    public float cost;

    /// <summary>
    /// Time until ability can be cast again.
    /// </summary>
    [Space(10)]
    public float cooldown;
    public float cooldownTimer;
    public bool onCooldown;
    [Space(10)]
    

    /// <summary>
    /// Is there a targeting step for the ability (true), or is it cast instantly (false)?
    /// </summary>
    public bool targeting;
    /// <summary>
    /// If there is a targeting step, is it targeting now?
    /// </summary>
    public bool startedTargeting;



    public abstract void Cast(Player caster);

    
}
