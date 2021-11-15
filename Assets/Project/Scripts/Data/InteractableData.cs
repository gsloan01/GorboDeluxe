using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractableData : ScriptableObject
{
    public string name;
    public interactableType interactType;

    public enum interactableType
    {
        Item, Door, Teleport, Dialogue, DropsItems
    }


}
