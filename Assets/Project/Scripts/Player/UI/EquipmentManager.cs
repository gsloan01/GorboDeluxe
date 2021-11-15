using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    Player thisPlayer;

    //Data
    public EquipmentData Head, Chest, Legs, Hands, Neck, Feet, Hand_One, Hand_Two;
    //Display
    public InventoryItemDisplay HeadDisplay, ChestDisplay, LegsDisplay, HandsDisplay,
                                NeckDisplay, FeetDisplay, Hand_OneDisplay, Hand_TwoDisplay;

    private void Awake()
    {
        thisPlayer = GetComponent<Player>();
    }

    bool TryEquip(EquipmentData newEquip)
    {
        bool success = false;
        switch (newEquip.equipmentType)
        {
            case EquipmentData.EquipmentType.Head:
                
                //if the slot is open
                if (Head == null)
                {
                    //equip the new item
                    Head = newEquip;
                    success = true;
                }
                else
                {
                    if(thisPlayer.inventory.TryAdd(Head))
                    {
                        Head = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Chest:

                //if the slot is open
                if (Chest == null)
                {
                    //equip the new item
                    Chest = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Chest))
                    {
                        Chest = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Legs:

                //if the slot is open
                if (Legs == null)
                {
                    //equip the new item
                    Legs = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Legs))
                    {
                        Legs = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Hands:

                //if the slot is open
                if (Hands == null)
                {
                    //equip the new item
                    Hands = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Hands))
                    {
                        Hands = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Feet:

                //if the slot is open
                if (Feet == null)
                {
                    //equip the new item
                    Feet = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Feet))
                    {
                        Feet = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Neck:

                //if the slot is open
                if (Neck == null)
                {
                    //equip the new item
                    Neck = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Neck))
                    {
                        Neck = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }

                break;
            case EquipmentData.EquipmentType.Weapon:
                if(Hand_One == null)
                {
                    Hand_One = newEquip;
                    success = true;
                }
                else if(Hand_Two == null)
                {
                    Hand_One = newEquip;
                    success = true;
                }
                else
                {
                    if (thisPlayer.inventory.TryAdd(Hand_One))
                    {
                        Hand_One = newEquip;
                        success = true;
                    }
                    else
                    {
                        Debug.Log("No space in inventory for the old item");
                    }
                }


                break;
            default:
                break;
        }
        return success;
    }
}
