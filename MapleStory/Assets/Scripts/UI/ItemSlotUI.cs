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

        if (itemData.amount > 1)
            countText.text = itemData.amount.ToString();
        else
            countText.text = ""; // 수량 1이면 안 보이게
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2) // 더블클릭일 때만
        {
            Debug.Log("더블클릭 감지됨");
            OnClick();
            
        }
    }
  
    public void OnClick()
    {
        if (itemData == null) return;

        if (itemData.itemType == ItemData.ItemType.Consumable)
        {
            Debug.Log($"{itemData.itemName} 사용됨!");
            // 포션 사용 처리
        }
        else if (itemData.itemType == ItemData.ItemType.Equipment)
        {
            // 장비 장착 처리
            var equipSlot = EquipmentManager.Instance.GetSlot(itemData.equipmentType);

            if (equipSlot != null)
            {
                // 이미 장착 중인 아이템은 인벤토리로 되돌리기
                if (!equipSlot.IsEmpty())
                {
                    InventoryManager.Instance.AddItem(equipSlot.GetItem());
                }

                equipSlot.Clear(); // 기존 장비 해제
                equipSlot.SetItem(itemData); // 새 장비 장착
                ClearSlot(); // 인벤토리 슬롯 비우기
            }
        }

    }


    // 이름이 같은 아이템인지 체크
    public bool HasItem(string itemName)
    {
        return itemData != null && itemData.itemName == itemName;
    }

    // 수량 추가
    public void AddAmount(int amount)
    {
        itemData.amount += amount;
        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
    }

    // 비었는지 확인
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
    


    // 툴팁 표시용 함수 
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
