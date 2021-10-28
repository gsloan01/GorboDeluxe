using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAbility : ScriptableObject
{
    public string abilName;
    public string desc;
    public float cost;
    public float cooldown;

    public bool hasClassReq;
    public Player.PlayerClass classReq;

    public UnityEvent OnAbilityStart;
    public UnityEvent OnAbilityEnd;
    public UnityEvent OnAbilityReady;

    public enum AbilityState
    {
        Start, Ongoing, End, OnCooldown, Ready
    }


    public void OnStartCast()
    {

    }

    public void OnFinishCast()
    {

    }
    
}
