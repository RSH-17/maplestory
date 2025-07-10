using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    public EquipmentSlotUI weaponSlot;
    public EquipmentSlotUI armorSlot;

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
            _ => null
        };
    }
}
