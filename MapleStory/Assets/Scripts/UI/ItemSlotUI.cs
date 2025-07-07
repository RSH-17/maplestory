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

        countText.text = itemData.amount > 1 ? itemData.amount.ToString() : "";
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
}
