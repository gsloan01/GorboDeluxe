using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDialogue", menuName ="Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueSegment> conversation;

}

[System.Serializable]
public struct DialogueSegment
{
    public string speaker;
    public Sprite speakerIcon;
    public string segment;

    public bool endAfterTime;
    public float delay;

}

