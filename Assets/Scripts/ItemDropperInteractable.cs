using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable that creates items (chest)
/// </summary>
public class ItemDropperInteractable : Interactable
{
    public List<ItemData> guaranteedDrops;
    public int numOfDrops = 1;
    public ItemData[] items;

    public override void Display()
    {
         //display the ui when in range
    }

    public override void Interact()
    {
        //Open chest
        
    }

    public override void RemoveDisplay()
    {
        //remove the display
    }

    
    void Start()
    {
        items = new ItemData[numOfDrops + guaranteedDrops.Count];

        for (int i = 0; i < guaranteedDrops.Count; i++)
        {
            items[i] = guaranteedDrops[i];
        }

        //then generate more items as you need
    }


}
