using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string name;



    public PlayerStat[] stats = new PlayerStat[5] { new PlayerStat(PlayerStat.eStat.Strength, 1),
                                                    new PlayerStat(PlayerStat.eStat.Dexterity, 1),
                                                    new PlayerStat(PlayerStat.eStat.Intelligence, 1),
                                                    new PlayerStat(PlayerStat.eStat.Wisdom, 1),
                                                    new PlayerStat(PlayerStat.eStat.Constitution, 1) };

}
[System.Serializable]
public class PlayerStat
{
    [System.Serializable]
    public enum eStat
    {
        Strength, Dexterity, Intelligence, Wisdom, Constitution
    }
    eStat stat;
    int value = 1;

    public PlayerStat(eStat s, int v)
    {
        stat = s;
        value = v;
    }
}

