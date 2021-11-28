using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(StatusEffectHandler))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class BossAI : MonoBehaviour
{
    public string bossName, desc;
    public List<EnemyData.EnemyType> types = new List<EnemyData.EnemyType>();
    [SerializeField] Transform shootTransform;
    [SerializeField] float phase1ShootDelay = 0.5f;
    [SerializeField] float phase2ShootDelay = 0.25f;
    [SerializeField] GameObject webshotTargeting;

    [SerializeField] List<Transform> addSpawns = new List<Transform>();
    Health health;
    NavMeshAgent agent;
    int phase = 0;
    [SerializeField] EnemyRangedAttack webShot;
    bool invuln;


    private void Awake()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();

        health.OnHurt.AddListener(CheckForPhaseChange);
    }



    public void StartCombat()
    {
        phase++;
        StartCoroutine(FollowPlayer());
    }

    IEnumerator FollowPlayer()
    {
        bool follow = true;
        while(follow)
        {
            agent.SetDestination(PlayerManager.Instance.player.transform.position);
            transform.rotation = Utility.FaceTarget(PlayerManager.Instance.player.gameObject, transform);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    #region Boss Moves
    IEnumerator SwipeAttack()
    {
        StopCoroutine(FollowPlayer());
        agent.isStopped = true;
        bool swiping = true;
        while(swiping)
        {

        }
        StartCoroutine(FollowPlayer());
        yield return null;
    }
    IEnumerator SpawnAdds()
    {
        yield return null;
    }
    IEnumerator ReturnFromCeiling()
    {
        yield return null;
    }
    IEnumerator ShootWebs()
    {
        StopCoroutine(FollowPlayer());
        for (int i = 0; i < (phase > 1 ? 5 : 3); i++)
        {
            EnemyRangedAttack newAttack = Instantiate(webShot, shootTransform.position, shootTransform.rotation);
            newAttack.targetingTransform = Instantiate(webshotTargeting, PlayerManager.Instance.player.transform.position, Quaternion.identity).transform;
            yield return new WaitForSeconds((phase > 1 ? 0.2f : 0.5f));
        }
        StartCoroutine(FollowPlayer());
        yield return null;
    }
    IEnumerator PoisonWindup()
    {
        yield return null;
    }
    #endregion

    #region Phase Change
    void CheckForPhaseChange()
    {
        if (phase != 2 && health.Current / health.max <= .5f)
        {
            phase++;
            StartCoroutine(StartPhaseChange());
        }
    }
    IEnumerator StartPhaseChange()
    {
        phase++;
        //start chargeupAnim
        health.invuln = true;
        yield return new WaitForSeconds(2);
        PhaseChange();
        health.invuln = false;

    }
    void PhaseChange()
    {
        Debug.Log("Phase 2 started");
        //cam shake
        //scene fx
        //color change
    }
    #endregion

    #region Death Clean Up
    IEnumerator Death()
    {
        StopCoroutine(FollowPlayer());
        yield return null;
    }
    void OnDeath()
    {
        StartCoroutine(Death());
    }
    #endregion

}
