using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    public GameObject stepFX;
    Animator animator;
    Player player;
    Health playerHealth;

    int baseIndex = 0;
    int movementIndex;

    private void Start()
    {
        player = GetComponent<Player>();
        playerHealth = player.GetComponent<Health>();
        animator = GetComponentInChildren<Animator>();
        movementIndex = animator.GetLayerIndex("Movement");

        playerHealth.OnDeath.AddListener(SetDeath);
        playerHealth.OnHurt.AddListener(SetHurt);
        
    }

    public void SetMovementSpeed(Vector2 movement)
    {
        animator.SetLayerWeight(movementIndex, movement.magnitude);
        
    }
    public void SetDeath()
    {
        animator.SetBool("Death", playerHealth.isDead);
    }
    public void SetHurt()
    {
        animator.SetTrigger("Hurt");
    }
    public void SetMeleeAttack1()
    {
        animator.SetTrigger("Melee1");
    }
    public void SetInteract()
    {
        animator?.SetTrigger("Interact");
    }
    public void SetRolling(bool rolling)
    {
        animator?.SetBool("Rolling", rolling);
    }
    public void SetRanged1()
    {
        animator?.SetTrigger("Ranged1");
    }




}


