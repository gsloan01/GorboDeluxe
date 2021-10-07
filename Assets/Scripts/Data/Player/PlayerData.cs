using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    //This is the players name
    public string name;

    //Strength constitutes the players damage with big weapons (warrior, hammers, etc)
    //Agility determines light weapon damage (rogue, archer, etc)
    //Intellect governs magical damage (wizards, warlocks, witches oh my!)
    //Willpower governs resource pool (mana or stamina)
    //Toughness is health and defense
    public int strength, agility, intellect, willpower, toughness;



    

}


