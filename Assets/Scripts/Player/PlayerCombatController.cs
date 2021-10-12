using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombatController : MonoBehaviour
{
    Player thisPlayer;
    PlayerInputHandler input;
    public GameObject PlayerBasicAttack;
    private void Awake()
    {
        thisPlayer = GetComponent<Player>();
        input = thisPlayer.inputHandler;
        input.OnBasicAttackBtn_Down.AddListener(Attack);
    }

    void Attack()
    {
        if(input.MK_Active)
        {
            if (GameSettings.Instance.debug) Debug.Log("Attacking with MK Controls");
            Instantiate(PlayerBasicAttack, transform.position, transform.rotation, null);
        }
    }
}
