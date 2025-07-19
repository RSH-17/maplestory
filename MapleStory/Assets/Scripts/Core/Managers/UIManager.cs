using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    public DialogueUI dialogueUI;
    public InventoryUI inventoryUI;
    public EquipmentUI equipmentUI;
    public QuestUI questUI;
    public TooltipUI tooltipUI;
    public StatUI statUI;

    void Awake()
    {
        // 싱글톤
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // 자동 참조 (필드에 직접 안 넣었을 경우)
        if (dialogueUI == null) dialogueUI = FindObjectOfType<DialogueUI>(true);
        if (inventoryUI == null) inventoryUI = FindObjectOfType<InventoryUI>(true);
        if (equipmentUI == null) equipmentUI = FindObjectOfType<EquipmentUI>(true);
        if (questUI == null) questUI = FindObjectOfType<QuestUI>(true);
        if (tooltipUI == null) tooltipUI = FindObjectOfType<TooltipUI>(true);
        if (statUI == null) statUI = FindObjectOfType<StatUI>(true);
    }
  
    // UI 전체 비활성화
    public void HideAll()
    {
        dialogueUI?.gameObject.SetActive(false);
        inventoryUI?.gameObject.SetActive(false);
        equipmentUI?.gameObject.SetActive(false);
        questUI?.gameObject.SetActive(false);
        tooltipUI?.gameObject.SetActive(false);
        statUI?.gameObject.SetActive(false);
    }

    // 예시로 UI 토글 함수
    public void ToggleInventory()
    {
        if (inventoryUI != null)
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public void ToggleEquipment()
    {
        if (equipmentUI != null)
        {
            equipmentUI.gameObject.SetActive(!equipmentUI.gameObject.activeSelf);
        }
    }

    public void ToggleQuest()
    {
        if (questUI != null)
        {
            questUI.gameObject.SetActive(!questUI.gameObject.activeSelf);
        }
    }
}
