using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> potionSlots = new List<InventorySlot>();
    public PlayerUI playerUI; // 플레이어 UI 연결

    public void UsePotion(PotionData potion)
    {
        foreach (var slot in potionSlots)
        {
            if (slot.potion == potion && slot.count > 0)
            {
                slot.count--;
                playerUI.UsePotion(potion);
                Debug.Log($"{potion.potionName} 사용 (남은 개수: {slot.count})");
                return;
            }
        }

        Debug.LogWarning("해당 포션 없음");
    }
}
