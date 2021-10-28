using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AOE Attack", menuName = "Player Abilities/Testing/AOE")]
public class TargetedAttackTest : Ability
{
    public AttackData data;
    //This will be the attack outline object;
    public GameObject targetPrefab;

    //this is what will spawn after that
    public GameObject attackPrefab;

    GameObject targetingGO = null;
    public bool targeting;

    public override void Cast(Player caster)
    {
        if(!targeting && targetingGO == null)
        {
            Debug.Log("BeginCast");
            targeting = true;
            targetingGO = Instantiate(targetPrefab, caster.inputHandler.MouseRayCastHitInfo.point, Quaternion.identity);
            targetingGO.GetComponent<AOETargeting>().input = caster.inputHandler;
        }
        else
        {
            //targetingGO.cast
            targetingGO.GetComponent<AOETargeting>().Cast();
            targeting = false;
            Debug.Log("End Cast");
        }
    }
}
