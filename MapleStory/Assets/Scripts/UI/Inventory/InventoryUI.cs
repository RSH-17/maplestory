using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Slot 설정")]
    public GameObject itemSlotPrefab;      // ItemSlot 프리팹
    public Transform slotContainer;        // 슬롯들이 들어갈 부모 오브젝트
    public int slotCount = 20;             // 총 슬롯 개수

    void Start()
    {
        InitSlots();
    }

    void InitSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(itemSlotPrefab, slotContainer);
            slot.name = $"ItemSlot_{i}";
        }
    }
}
