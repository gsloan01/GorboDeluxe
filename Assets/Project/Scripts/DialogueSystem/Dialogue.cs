using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/DialogueConversation")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    public List<DialogueSegment> conversation;

}

[System.Serializable]
public struct DialogueSegment
{
    public DialogueProfile speaker;
    public string segment;
    public bool endAfterTime;
    public float delay;

    public Quest quest;
}




