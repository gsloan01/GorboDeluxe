using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/Inventory")]
public class Inventory : ScriptableObject
{
    public const int maxSize = 100;
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public bool TryAdd(ItemData item)
    {
        bool success = false;
        //if there is space for the item
        if(inventory.Count != maxSize)
        {
            if (item.stackSize == 1)
            {
                AddNewItem(item);
                success = true;
            }
        }
        else if(FindInventoryItem(item, out InventoryItem found))
        {
            if(found.count <= item.stackSize)
            {
                found.count++;
                success = true;
                
            }
        }
        return success;
        
    }
    void AddNewItem(ItemData item)
    {
        inventory.Add(new InventoryItem(item));
    }

    bool FindInventoryItem(ItemData item, out InventoryItem found)
    {
        found = new InventoryItem(item);
        foreach(InventoryItem i in inventory)
        {
            if(i.item == item)
            {
                found = i;
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public struct InventoryItem
{
    static int idcount = 0;
    public ItemData item;
    public int id;
    public int count;

    public InventoryItem(ItemData data)
    {
        item = data;
        count = 1;
        id = idcount++;
    }

    
}
