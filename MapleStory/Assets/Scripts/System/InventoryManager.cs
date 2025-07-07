using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤으로 접근

    public Transform slotContainer; // SlotContainer 오브젝트
    public GameObject itemSlotPrefab; // ItemSlot 프리팹

    private List<ItemSlotUI> slots = new List<ItemSlotUI>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitSlots(10); // 원하는 슬롯 수
    }

    void InitSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(itemSlotPrefab, slotContainer);
            var slot = go.GetComponent<ItemSlotUI>();
            slots.Add(slot);
        }
    }

    // 아이템 추가 함수
    public void AddItem(ItemData item)
    {
        // 이미 같은 아이템이 있으면 수량만 증가
        foreach (var slot in slots)
        {
            if (slot.HasItem(item.itemName))
            {
                slot.AddAmount(1); // 1개 증가
                return;
            }
        }

        // 빈 슬롯 찾아서 등록
        foreach (var slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                return;
            }
        }

        Debug.Log("인벤토리에 공간이 없습니다!");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemData potion = new ItemData
            {
                itemName = "Red Potion",
                icon = Resources.Load<Sprite>("Icons/HP_Potion_Icon"),
                description = "HP를 30 회복합니다.",
                itemType = ItemData.ItemType.Consumable,
                recoverHP = 30,
                recoverMP = 0,
                amount = 1
            };
            Debug.Log("스페이스 눌림");

            AddItem(potion);
        }
        

    
    }

}
