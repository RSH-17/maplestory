using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image iconImage;
    public TMP_Text countText;

    private ItemData itemData;

    public void ClearSlot()
    {
        itemData = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
        countText.text = "";
    }

    public void SetItem(ItemData newItem)
    {
        itemData = newItem;

        iconImage.sprite = itemData.icon;
        iconImage.enabled = true;

        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log(" 더블클릭 감지됨");
            OnClick();
        }
    }

    public void OnClick()
    {
        if (itemData == null) return;

        if (itemData.itemType == ItemData.ItemType.Consumable)
        {
            Debug.Log($"{itemData.itemName} 사용됨!");
            // 포션 등 소비 아이템 처리 예정
        }
        else if (itemData.itemType == ItemData.ItemType.Equipment)
        {
            Debug.Log($"장비 아이템 장착 시도: {itemData.itemName}");

            var equipSlot = EquipmentManager.Instance.GetSlot(itemData.equipmentType);
            if (equipSlot != null)
            {
                if (!equipSlot.IsEmpty())
                {
                    Debug.Log("기존 장비를 인벤토리로 이동");
                    InventoryManager.Instance.AddItem(equipSlot.GetItem());
                }

                equipSlot.Clear();
                equipSlot.SetItem(itemData);
                ClearSlot();

                Debug.Log(" 장비 장착 완료");
            }
            else
            {
                Debug.LogWarning($" 장비 슬롯을 찾을 수 없습니다: {itemData.equipmentType}");
            }
        }
    }

    public bool HasItem(string itemName)
    {
        return itemData != null && itemData.itemName == itemName;
    }

    public void AddAmount(int amount)
    {
        itemData.amount += amount;
        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
    }

    public bool IsEmpty()
    {
        return itemData == null;
    }

    public ItemData GetItem()
    {
        return itemData;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemData == null) return;

        TooltipUI tooltip = FindAnyObjectByType<TooltipUI>();
        if (tooltip != null)
            tooltip.Show(itemData.itemName, itemData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI tooltip = FindAnyObjectByType<TooltipUI>();
        if (tooltip != null)
            tooltip.Hide();
    }
}
