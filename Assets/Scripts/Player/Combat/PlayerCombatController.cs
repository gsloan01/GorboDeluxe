using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombatController : MonoBehaviour
{
    Player thisPlayer;
    PlayerInputHandler input;
    public Ability PrimaryAttack;
    float primaryTimer;
    bool primaryOnCooldown;

    private void Awake()
    {
        thisPlayer = GetComponent<Player>();
        input = thisPlayer.inputHandler;
        input.OnBasicAttackBtn_Down.AddListener(Attack);
    }

    private void Update()
    {
        if(primaryOnCooldown)
        {
            primaryTimer += Time.deltaTime;
            if (primaryTimer >= PrimaryAttack.cooldown)
            {
                primaryTimer = 0;
                primaryOnCooldown = false;
            }
        }
    }

    void Attack()
    {
        if(!primaryOnCooldown)
        {
            primaryOnCooldown = true;
            PrimaryAttack.Cast(thisPlayer);
        }

    }
}
