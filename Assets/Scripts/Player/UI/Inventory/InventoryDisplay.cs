using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Sprite defaultFrame;
    public Sprite junkFrame;
    public Sprite commonFrame;
    public Sprite uncommonFrame;
    public Sprite rareFrame;
    public Sprite epicFrame;
    public Sprite legendFrame;
    public Sprite mythicFrame;

    
    Inventory Inventory;
    InventoryItemDisplay[] inventoryItems;
    private void Awake()
    {
        Inventory = PlayerManager.Instance.players[0].GetComponent<Player>().inventory;
    }
    private void OnEnable()
    {
        UpdateInventory();
    }
    #region Sorting
    public void OnSortByRarity()
    {

    }
    public void OnSortByValue()
    {

    }
    public void OnSortByTotal()
    {

    }
    #endregion
    public void UpdateInventory()
    {
        List<InventoryItem> items = Inventory.inventory;
        inventoryItems = GetComponentsInChildren<InventoryItemDisplay>();
        for (int i = 0; i < 42; i++)
        {
            if (items.Count - 1 < i)
            {
                inventoryItems[i].ResetThis();
            }
            if (i < items.Count)
            {
                inventoryItems[i].Set(items[i], items[i].count);

            }
        }
    }
    public void OnDropItem(InventoryItemDisplay selected)
    {
        Debug.Log($"Trying to drop {selected.item.item.name}");
        bool success = Inventory.TryDropItem(selected.item.item, PlayerManager.Instance.player.transform);
        if (success)
        {
            Debug.Log($"{selected.item.item.name} Dropped");
            selected.ResetThis();
            UpdateInventory();
        }
    }
    public void OnItemSelected(InventoryItemDisplay selected)
    {
        
        
    }
}
