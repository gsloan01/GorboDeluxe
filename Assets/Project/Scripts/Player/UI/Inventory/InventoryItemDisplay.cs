using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemInfoDisplay infoDisplay;
    public InventoryItem item;
    public Image itemIcon;
    public TMP_Text item_amount;
    InventoryDisplay display;



    private void OnEnable()
    {
        display = GetComponentInParent<InventoryDisplay>();
        
    }

    public void Set(InventoryItem item, int count)
    {
        this.item = item;
        itemIcon.sprite = item.item.icon;
        itemIcon.gameObject.SetActive(true);
        item_amount.text = $"{count}";
        item_amount.gameObject.SetActive(true);
    }
    public void ResetThis()
    {
        item = new InventoryItem();
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
        item_amount.text = "";
        item_amount.gameObject.SetActive(false);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        // if this display is holding an item
        if(item.item != null)
        {
            //check for right click
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log($"{item.item.name}'s inventory display selected for drop.");
                //start dropping the item
                display.OnDropItem(this);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (infoDisplay != null && item.item != null) infoDisplay.PopUp(item.item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (infoDisplay != null) infoDisplay.GoAway();
    }
}
