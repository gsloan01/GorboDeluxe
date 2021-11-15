using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    //public ItemPickupUI ui;
    
    public GameObject itemObjectHolder;

    private void Awake()
    {
        id = -1;
    }
    private void Start()
    {
        Instantiate(((ItemData)data).mesh, itemObjectHolder.transform);

    }
    public override void Display()
    {
        //change from type to all info
    }

    public override void Interact(Player player)
    {
        Destroy(gameObject);
    }

    public override void RemoveDisplay()
    {
        //change from info to type
    }

    public void SetData(ItemData data)
    {
        this.data = data;
        Instantiate(data.mesh, itemObjectHolder.transform);
        //icon = data.icon
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(id == -1) id = idcounter++;
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
