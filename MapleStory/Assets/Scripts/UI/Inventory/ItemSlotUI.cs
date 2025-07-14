using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image iconImage;
    public TMP_Text countText;

    private ItemData itemData;

    public void SetItem(ItemData newItem)
    {
        itemData = newItem;

        iconImage.sprite = itemData.icon;
        iconImage.enabled = true;

        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
    }   

    public void ClearSlot()
    {
        itemData = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
        countText.text = "";
    }

    public void AddAmount(int amount)
    {
        itemData.amount += amount;
        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
    }

    public void DecreaseAmount(int value)
    {
        itemData.amount -= value;

        if (itemData.amount <= 0)
        {
            ClearSlot();
        }
        else
        {
            countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
        }
    }

    public bool IsEmpty()
    {
        return itemData == null;
    }

    public ItemData GetItem()
    {
        return itemData;
    }

    
    public bool HasItem(string itemName)
    {
        return itemData != null && itemData.itemName == itemName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            OnClick();
        }
    }

    public void OnClick()
{
    if (itemData == null) return;

    if (itemData.itemType == ItemType.Equipment)
    {
        EquipmentItemData equipment = itemData as EquipmentItemData;

        if (equipment == null)
        {
            Debug.LogWarning("❌ EquipmentItemData로 변환 실패");
            return;
        }

        var slot = EquipmentManager.Instance.GetSlot(equipment.equipmentType);

        if (slot == null)
        {
            Debug.LogWarning("❌ 장비 슬롯을 찾을 수 없습니다: " + equipment.equipmentType);
            return;
        }

        if (!slot.IsEmpty())
        {
            InventoryManager.Instance.AddItem(slot.GetItem());
        }

        slot.Clear();
        slot.SetItem(equipment);
        ClearSlot();

        Debug.Log("✅ 장비 장착 완료");
    }
}


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemData == null) return;

        TooltipUI tooltip = FindAnyObjectByType<TooltipUI>();
        if (tooltip != null)
        {
            tooltip.Show(itemData.itemName, itemData.description);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI tooltip = FindAnyObjectByType<TooltipUI>();
        if (tooltip != null)
        {
            tooltip.Hide();
        }
    }
}
