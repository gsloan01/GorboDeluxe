using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Data/Attacks/AttackData")]
public class AttackData : ScriptableObject
{
    public List<Damage.dtype> types;
    public List<float> values;  
}
