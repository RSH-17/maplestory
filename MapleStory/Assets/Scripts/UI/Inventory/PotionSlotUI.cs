using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlotUI : MonoBehaviour
{
    public PotionData potionData;
    public TextMeshProUGUI countText;
    public Button useButton;
    public Inventory inventory;

    public void SetSlot(PotionData data, int count, Inventory inv)
    {
        potionData = data;
        inventory = inv;
        UpdateCount(count);

        useButton.onClick.RemoveAllListeners(); // 중복 방지
        useButton.onClick.AddListener(() =>
{
    Debug.Log("슬롯 클릭됨!");
    inventory.UsePotion(potionData);
});
    }

    public void UpdateCount(int count)
    {
        countText.text = $"x{count}";
    }
    
}
