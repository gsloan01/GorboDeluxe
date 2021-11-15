using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/Player/MovementData")]
public class PlayerMovementData : ScriptableObject
{
    public float speed = 5;
    public float sprintSpeed = 7;
    public float rotateRate = 720f;
    public float sprintDelay = 3.0f;
}
