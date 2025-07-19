using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlotUI : MonoBehaviour, IPointerClickHandler
{
    public EquipmentType slotType;
    public Image iconImage;
    private ItemData equippedItem;

    public void SetItem(ItemData item)
    {
        equippedItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;

        var player = FindAnyObjectByType<PlayerStats>();
        player?.Equip(item);
    }

    public void Clear()
    {
        if (equippedItem != null)
        {
            var player = FindAnyObjectByType<PlayerStats>();
            player?.Unequip(equippedItem);
        }

        equippedItem = null;

        if (iconImage != null)
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
    }

    public bool IsEmpty() => equippedItem == null;

    public ItemData GetItem() => equippedItem;

    // 클릭 시 해제
    public void OnPointerClick(PointerEventData eventData)
    {  
        if (IsEmpty()) return;

        Debug.Log($" 장비 해제: {equippedItem.itemName}");

        // 인벤토리로 되돌리기
        InventoryManager.Instance.AddItem(equippedItem);
        Clear();
    }
}
