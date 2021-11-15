using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    #region Frames
    [SerializeField] Sprite defaultFrame;
    [SerializeField] Sprite junkFrame;
    [SerializeField] Sprite commonFrame;
    [SerializeField] Sprite uncommonFrame;
    [SerializeField] Sprite rareFrame;
    [SerializeField] Sprite epicFrame;
    [SerializeField] Sprite legendFrame;
    [SerializeField] Sprite mythicFrame;
    #endregion

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

    public void Swap(InventoryItemDisplay i, InventoryItemDisplay j)
    {
        InventoryItem temp = i.item;
        i.item = j.item;
        j.item = temp;
        UpdateInventory();
    }

    public void OnItemSelected(InventoryItemDisplay selected)
    {
        
        
    }
}
