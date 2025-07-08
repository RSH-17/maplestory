using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    public ItemData.EquipmentType slotType;
    public Image iconImage;
    private ItemData equippedItem;

    public void SetItem(ItemData item)
    {
        equippedItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;

        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        player?.Equip(item);
    }

    public void Clear()
    {
        if (equippedItem != null)
        {
            PlayerStats player = FindAnyObjectByType<PlayerStats>();  
            player?.Unequip(equippedItem);
        }

        equippedItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }

    public bool IsEmpty()
    {
        return equippedItem == null;
    }

    public ItemData GetItem()
    {
        return equippedItem;
    }
}
