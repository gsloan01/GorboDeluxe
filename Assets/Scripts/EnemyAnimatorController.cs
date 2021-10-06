using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator animator;

    public void HurtAnim()
    {
        animator.SetTrigger("Hurt");
    }

    public void AttackAnim()
    {
        animator.SetTrigger("Attack");
    }
    public void WalkingAnim( bool isWalking)
    {
        animator.SetBool("Walk", isWalking);
    }
    public void IdleAnim(bool isIdle)
    {
        animator.SetBool("Idle", isIdle);
    }


}
