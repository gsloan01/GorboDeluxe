using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public string name;
    public ClassData classData;
    
    [SerializeField]
    public PlayerAbility ability1;
    [SerializeField]
    public PlayerAbility ability2;
    [SerializeField]
    public PlayerAbility ability3;
}
