using UnityEngine;

public class ItemActionHandler
{
    public void UseItem(ItemData item)
    {
        if (item is IUsable usable)
        {
            usable.Use();
        }
    }

    public void EquipItem(EquipmentItemData item)
    {
        var slot = EquipmentManager.Instance.GetSlot(item.equipmentType);

        if (slot != null)
        {
            if (!slot.IsEmpty())
            {
                InventoryManager.Instance.AddItem(slot.GetItem());
            }

            slot.SetItem(item);
        }
        else
        {
            Debug.LogWarning($"장비 슬롯을 찾을 수 없습니다: {item.equipmentType}");
        }
    }
}
