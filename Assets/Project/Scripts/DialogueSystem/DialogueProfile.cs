using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/DialogueProfile")]
public class DialogueProfile : ScriptableObject
{
    public string speakerName;
    public Sprite speakerIcon;
    public List<AudioClip> sounds;
}
