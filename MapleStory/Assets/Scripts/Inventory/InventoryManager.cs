using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance{ get; private set; } // 싱글톤으로 접근

    public Transform slotContainer; // SlotContainer 오브젝트
    public GameObject itemSlotPrefab; // ItemSlot 프리팹

    private List<ItemSlotUI> slots = new List<ItemSlotUI>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        InitSlots(10); // 원하는 슬롯 수
    }

    void InitSlots(int count)
    {
        slots.Clear();
        foreach (Transform child in slotContainer)
        {
            var slot = child.GetComponent<ItemSlotUI>();
            if (slot != null)
            {
                slots.Add(slot);
                slot.ClearSlot(); // 초기화
            }
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var potion = Resources.Load<ConsumableItemData>("Items/HP_Potion");
            if (potion != null)
            {
                InventoryManager.Instance.AddItem(potion);
            }
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            var sword = Resources.Load<EquipmentItemData>("Items/Iron_Sword");
            if (sword != null)
            {
                InventoryManager.Instance.AddItem(sword);
            }
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            var mpPotion = Resources.Load<ConsumableItemData>("Items/Mp_Potion");
            
            if (mpPotion == null)
            {
                Debug.LogError("❌ MP_Potion 로드 실패!");
            }
            else
            {
                Debug.Log("✅ MP_Potion 로드 성공: " + mpPotion.itemName);
                InventoryManager.Instance.AddItem(mpPotion);
            }
        }


        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            UseFirstPotion();
        }
    }

    public void UseFirstPotion()
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty()) continue;

            var item = slot.GetItem();

            if (item is ConsumableItemData consumable)
            {
                Debug.Log($"포션 사용: {consumable.itemName}");

                PlayerStats player = Object.FindFirstObjectByType<PlayerStats>();
                if (player != null)
                {
                    player.UsePotion(consumable.recoverHP, consumable.recoverMP);
                }

                slot.DecreaseAmount(1);
                return;
            }
        }

        Debug.Log("사용 가능한 포션이 없습니다!");
    }



}
