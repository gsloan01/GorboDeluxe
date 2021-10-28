using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RogueSlash", menuName = "Player Abilities/Rogue/RogueSlash")]
public class RogueSlash : Ability
{
    [SerializeField]
    public AttackData attackData;
    public GameObject slashPrefab;
    public override void Cast(Player caster)
    {
        //Make Player do animation
        Instantiate(slashPrefab, caster.transform.position, caster.transform.rotation);
    }
}
