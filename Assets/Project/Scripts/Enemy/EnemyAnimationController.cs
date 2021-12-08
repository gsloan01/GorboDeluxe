using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }
    public void SetWalk(Vector2 move)
    {
        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveY", move.y);
    }
    public void SetDeath()
    {
        animator.SetBool("Death", true);
    }
    public void SetHurt()
    {
        animator.SetTrigger("Hurt");
    }
    public void SetAttack1()
    {
        animator.SetTrigger("Attack1");
    }
    public void SetAttack2()
    {
        animator.SetTrigger("Attack2");
    }
    public void SetAttack3()
    {
        animator.SetTrigger("Attack3");
    }
}
