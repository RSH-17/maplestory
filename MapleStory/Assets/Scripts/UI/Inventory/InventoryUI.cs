using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;
    public Inventory inventory;

    private List<PotionSlotUI> activeSlots = new();

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (var slot in activeSlots)
        {
            Destroy(slot.gameObject);
        }
        activeSlots.Clear();

        foreach (var slotData in inventory.potionSlots)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent);
            PotionSlotUI slotUI = obj.GetComponent<PotionSlotUI>();
            slotUI.SetSlot(slotData.potion, slotData.count, inventory);
            activeSlots.Add(slotUI);
        }
    }
}
