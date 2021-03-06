using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/Inventory")]
public class Inventory : ScriptableObject
{
    public const int maxSize = 42;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public ItemInteractable itemPrefab;
    public UnityEvent<ItemData> OnItemAdded;
    public enum InventorySortMethod
    { Rarity, Value, ItemType }

    public float dropMaxForceY = 10.0f;
    public float dropMaxForceXZ = 10.0f;

    public bool TryAddItems(List<ItemData> items)
    {
        bool fullSuccess = true;
        foreach (ItemData item in items)
        {
            if (!TryAdd(item))
            {
                Debug.Log($"Couldnt add {item.name} to inventory");
                fullSuccess = false;
            }
        }
        return fullSuccess;
    }

    public bool TryAdd(ItemData item)
    {
        bool success = false;
        //if there is space for the item
        if (FindInventoryItem(item, out int foundAt))
        {
            if (inventory[foundAt].count <= item.stackSize)
            {
                inventory[foundAt].Add(1);
                success = true;
                OnItemAdded.Invoke(item);
            }

        }
        else if (inventory.Count != maxSize)
        {

            AddNewItem(item);
            success = true;
            OnItemAdded.Invoke(item);

        }
        

        return success;
        
    }
    void AddNewItem(ItemData item)
    {
        inventory.Add(new InventoryItem(item));
    }

    bool FindInventoryItem(ItemData item, out int foundIndex)
    {
        foundIndex = -1;
        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].item == item)
            {
                foundIndex = i;
                Debug.Log("Inventory item found");
                return true;
            }
        }
        return false;
    }
    void DropItem(ItemData item, Transform playerTransform)
    {
        Vector3 dropPos = new Vector3(playerTransform.position.x, playerTransform.position.y + 2, playerTransform.position.z);
        ItemInteractable droppedItem = Instantiate(itemPrefab, dropPos, Quaternion.identity);
        droppedItem.SetData(item);
        droppedItem.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-dropMaxForceXZ, dropMaxForceXZ), Random.Range(1, dropMaxForceY), Random.Range(-dropMaxForceXZ, dropMaxForceXZ)));
    }

    public bool TryDropItem(ItemData item, Transform playerTransform)
    {

        bool findInventoryItem = FindInventoryItem(item, out int foundAt);
        InventoryItem inventoryItem = inventory[foundAt];
        Debug.Log("Inventory.cs / TryDrop Item / Does this method find that item in that inventory : " + findInventoryItem);
        if (findInventoryItem)
        {
            inventoryItem.Add(-1);
            Debug.Log($"Item count : {inventoryItem.count}");
            DropItem(item, playerTransform);
            if (inventoryItem.count <= 0)
            {
                Debug.Log("Item's count is less than or equal to zero, removing from inventory");
                
                inventory.RemoveAt(foundAt);
                //Debug.Log(success ? "Item Successfully Removed" : "Item not removed successfully");
            }
            
        }

        return findInventoryItem;


    }

    public void Sort( InventorySortMethod sortMethod, bool descending)
    {
        switch (sortMethod)
        {
            case InventorySortMethod.Rarity:
                break;
            case InventorySortMethod.Value:
                break;
            case InventorySortMethod.ItemType:
                break;
            default:
                break;
        }
    }

    public void SortByRarity()
    {

    }
    public void SortByValue()
    {

    }
    public void SortByType()
    {

    }

}

[System.Serializable]
public struct InventoryItem
{
    static int idcount = 0;
    public ItemData item;
    public int id;
    public int count { get { return _count; } set { count = value; } }
    int _count;

    public InventoryItem(ItemData data)
    {
        item = data;
        id = idcount++;
        _count = 1;
    }

    public void Add(int amount)
    {
        Debug.Log($"Adding {amount} to {item.name}'s count. Current count is {count}.");
        _count += amount;
        Debug.Log($"Count is now {count}");
    }


    
}
