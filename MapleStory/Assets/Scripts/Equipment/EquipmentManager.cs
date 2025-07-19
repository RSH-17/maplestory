using UnityEngine;
public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    public EquipmentSlotUI weaponSlot;
    public EquipmentSlotUI armorSlot;
    public EquipmentSlotUI accessorySlot;

    void Awake()
    {
        Instance = this;
    }

    public EquipmentSlotUI GetSlot(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.Weapon: return weaponSlot;
            case EquipmentType.Armor: return armorSlot;
            case EquipmentType.Accessory: return accessorySlot;
            default: return null;
        }
    }

    public void Equip(EquipmentItemData item)
    {
        EquipmentSlotUI slot = GetSlot(item.equipmentType);
        if (slot == null) return;

        if (!slot.IsEmpty())
        {
            InventoryManager.Instance.AddItem(slot.GetItem());
        }

        slot.SetItem(item);
    }
}
