using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    public InteractableData data;
    public bool isInteractable;
    /// <summary>
    /// This method will handle when the player interacts with the interactable.
    /// </summary>
    public abstract void Interact();
    /// <summary>
    /// This method handles displaying the relevant information
    /// </summary>
    public abstract void Display();

    /// <summary>
    /// This method removes the display shown for the interactable
    /// </summary>
    public abstract void RemoveDisplay();
}
