using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public override void Display()
    {
        
    }

    public override void Interact()
    {
        Destroy(gameObject);
    }

    public override void RemoveDisplay()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
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
