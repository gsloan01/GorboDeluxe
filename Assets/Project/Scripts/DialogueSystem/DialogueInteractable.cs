using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{

    
    public override void Display()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(Player player)
    {
        player.dialogueUI.StartDialogue(((DialogueInteractableData)(data)).dialogue);
    }

    public override void RemoveDisplay()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (id == -1) id = idcounter++;
            other.GetComponent<Player>().OnEnterInteraction(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().OnExitInteraction(this);
        }
    }
}
