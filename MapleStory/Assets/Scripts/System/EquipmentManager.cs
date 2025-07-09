using UnityEngine;
using System;
public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    public EquipmentSlotUI weaponSlot;
    public EquipmentSlotUI armorSlot;
    public EquipmentSlotUI accessorySlot; // 선택

    void Awake()
    {
        Instance = this;
    }

    public EquipmentSlotUI GetSlot(ItemData.EquipmentType type)
    {
        return type switch
        {
            ItemData.EquipmentType.Weapon => weaponSlot,
            ItemData.EquipmentType.Armor => armorSlot,
            ItemData.EquipmentType.Accessory => accessorySlot,
            _ => null
        };
    }
}
