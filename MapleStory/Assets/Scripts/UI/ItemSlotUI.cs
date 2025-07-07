using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text countText;

    private ItemData itemData;

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

    public void OnClick()
    {
        if (itemData == null) return;

        if (itemData.itemType == ItemData.ItemType.Consumable)
        {
            Debug.Log($"{itemData.itemName} 사용됨!");
            // TODO: 회복 처리 등 호출
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

}
