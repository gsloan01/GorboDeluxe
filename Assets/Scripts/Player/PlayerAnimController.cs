using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    List<TimerStructure> timers = new List<TimerStructure>();
    Animator animator;
    Player player;
    PlayerMovement playerMovement;
    bool animMoving;
    public GameObject stepFX;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponentInParent<Player>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }


    private void Update()
    {
        if(playerMovement.Moving && !animMoving )
        {
            MoveAnim(true);
            IdleAnim(false);
        }
        else if(!playerMovement.Moving && animMoving)
        {
            MoveAnim(false);
            IdleAnim(true);
        }
        //for (int i = 0; i < timers.Count; i++)
        //{
        //    TimerStructure t = timers[i];
        //    t.timer -= Time.deltaTime;
        //    if(t.timer <= 0)
        //    {
        //        switch (t.id)
        //        {
        //            case "MeleeAttack":
        //                MeleeAttackAnim();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }


    public void ThrustAttackAnim(float delay = 0)
    {
        animator.SetTrigger("MeleeAttack");
    }

    public void ShieldAttackAnim()
    {
        animator.SetTrigger("ShieldBash");
    }

    public void DeathAnim(bool isDead)
    {
        animator.SetTrigger("Dead");
    }
    public void YellAnim()
    {
        animator.SetTrigger("Yell");
    }
    public void MoveAnim(bool isMoving)
    {
        animator.SetBool("Running", isMoving);
        animMoving = isMoving;
    }
    public void IdleAnim(bool value)
    {
        if(animator.GetBool("Idle") != value)
        {
            animator.SetBool("Idle", value);
        }

    }

    public void Footstep()
    {
        Instantiate(stepFX, transform.position, player.transform.rotation, null);
    }
}

public class TimerStructure
{
    public string id;
    public float timer { get { return timer; } set { timer = value; } }

    public TimerStructure(string ID, float Timer)
    {
        id = ID;
        timer = Timer;
    }

}
