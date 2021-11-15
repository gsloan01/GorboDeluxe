using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    public Quest quest;
}

