using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WeaponData : EquipmentData
{
    public const EquipmentType equipmentType = EquipmentType.Weapon;
    public enum WeaponType
    {
        _1HSword, _2HSword, Dagger, Bow, Staff, Axe, _1HMace, _2HHammer
    }
    public AttackData damageBonuses;
    public int strBonus, agilBonus, intBonus, willBonus, fortBonus = 0;
    public StatusEffect bonusEffect;

}

