using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public string name;
    public ClassData classData;
    
    //Basic Attack
    [SerializeField]
    public PlayerAbility ability1;
    //
    [SerializeField]
    public PlayerAbility ability2;
    //
    [SerializeField]
    public PlayerAbility ability3;
    //
    [SerializeField]
    public PlayerAbility ability4;
    //
    [SerializeField]
    public PlayerAbility ability5;
    //
    [SerializeField]
    public PlayerAbility ability6;
}
