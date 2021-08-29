using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    public ClassData classData;
    Player player;
    public List<PlayerAbility> availableAbilities = new List<PlayerAbility>();
    
    void Awake()
    {
        player = GetComponent<Player>();
    }

    public void OnLevelUp()
    {
        List<PlayerAbility> list = classData.GetAbilitiesByLevel(player.Level);
        if(list != null)
        {
            foreach(PlayerAbility pa in list)
            {
                availableAbilities.Add(pa);
            }
        }
        
    }
}
