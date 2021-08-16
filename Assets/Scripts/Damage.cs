using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float value;
    public dtype damageType;
    public enum dtype
    {
        Physical, Magical
    }

}
