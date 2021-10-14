using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Interactable/Item")]
public class ItemData : InteractableData
{
    
    public string description;
    
    public ItemType type;
    public Rarity rarity;
    public int value;
    public bool canDrop;
    public int stackSize;

    public GameObject mesh;
    public Sprite icon;


    public enum Rarity
    {
        Trash, Common, Uncommon, Rare, Epic, Legendary, Mythic
    }

    public enum ItemType
    {
        Equipment, Consumable, Crafting, Junk, QuestItem
    }

}
