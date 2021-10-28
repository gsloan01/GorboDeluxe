using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string name;
    public string desc;
    public Sprite icon;
    public float cooldown;

    public Player.PlayerClass playerClass;

    public abstract void Cast(Player caster);
}
