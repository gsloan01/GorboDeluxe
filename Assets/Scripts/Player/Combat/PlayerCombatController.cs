using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombatController : MonoBehaviour
{
    Player thisPlayer;
    PlayerInputHandler input;
    public List<PlayerAbility> abilities;

    private void Awake()
    {
        thisPlayer = GetComponent<Player>();
        input = thisPlayer.inputHandler;
        input.OnBasicAttackBtn_Down.AddListener(BasicAttack);
        input.OnBasicAttackBtn_Up.AddListener(BasicAttack);
    }

    private void Update()
    {
        Cooldown();

    }

    void BasicAttack()
    {
        abilities[0].Cast(thisPlayer);
    }


    /// <summary>
    /// Goes through all abilities and ticks their cooldowns.
    /// </summary>
    void Cooldown()
    {
        foreach(PlayerAbility ability in abilities)
        {
            if (ability.onCooldown)
            {
                ability.cooldownTimer += Time.deltaTime;
                

                if (ability.cooldownTimer >= ability.cooldown)
                {
                    ability.cooldownTimer = 0;
                    ability.onCooldown = false;
                }
            }
        }
    }
}
