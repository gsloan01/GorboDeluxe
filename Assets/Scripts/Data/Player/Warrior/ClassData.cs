using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassData", menuName = "Data/Player/ClassData")]
public class ClassData : ScriptableObject
{
    public Player.PlayerClass playerClass;
    public List<levelAbility> classAbilities;



    public List<PlayerAbility> GetAbilitiesByLevel(int level, bool includeLower = false)
    {
        List<PlayerAbility> found = new List<PlayerAbility>();

        foreach(levelAbility levelAbility in classAbilities)
        {
            if(levelAbility.unlockLvl == level)
            {
                found.Add(levelAbility.abil);
            }
            if(includeLower && levelAbility.unlockLvl < level)
            {
                found.Add(levelAbility.abil);
            }
        }


        return found;
    }
}
[System.Serializable]
public struct levelAbility
{
    public int unlockLvl;
    public PlayerAbility abil;
}

