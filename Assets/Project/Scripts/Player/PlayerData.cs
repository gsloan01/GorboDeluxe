using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName = "Data/Player/New Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int lvl = 1;
    public float totalXP = 0;
    public float xpGoal = 50;

    public int Gold;
    public float goldMultiplier = 1;
    public float xpMultiplier = 1;

    public int strength, agility, intellect, willpower, fortitude = 1;
    public PlayerMovementData movementData;
    public AudioClip LVLUP_SFX;
    public int skillPointsAvail = 0;
    public void OnGainXP(float gained)
    {
        float realGained = gained * xpMultiplier;
        totalXP += realGained;
        Debug.Log($"{playerName} has gained {realGained} xp! Bringing them to {totalXP}");
        //if leveling is possible
        if (levels.TryGetValue(lvl, out float needed))
        {
            if (totalXP >= xpGoal)
            {
                OnLvlUp();
            }
        }
        else
        {
            Debug.Log("Max Level Reached");
        }


    }
    public void OnLvlUp()
    {
        //Call ui method to display this
        //make the next goal the next needed value
        lvl++;
        levels.TryGetValue(lvl, out float newGoal);
        xpGoal = newGoal;
        skillPointsAvail += 3;
        Debug.Log($"{playerName} has leveled up! Now LVL {lvl}.");
        PlayerManager.Instance.player.GetComponent<Player>().OnLvlUp();
        SFXManager.Instance.PlaySFX(LVLUP_SFX, PlayerManager.Instance.player.transform);
    }

    public bool OnGoldChange(int change)
    {
        bool success = false;
        if(Gold + Mathf.Round(change * goldMultiplier) > 0)
        {
            Gold += change;
            success = true;
        }
        return success;
        
        
    }
    public Dictionary<int, float> levels = new Dictionary<int, float>()
    {
        //LVL, REQXP
        {1, 50 },
        {2, 100 },
        {3, 200 },
        {4, 500 },
        {5, 700 }
    };

}
