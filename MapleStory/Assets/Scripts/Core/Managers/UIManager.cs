using UnityEngine;

namespace Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        // UI 오브젝트 참조
        public GameObject HPbar { get; private set; }
        public GameObject MPbar { get; private set; }
        public GameObject EXPbar { get; private set; }

        public GameObject InventoryPanel { get; private set; }
        public GameObject InventoryTooltip { get; private set; }
        public GameObject EquipmentPanel { get; private set; }
        public GameObject StatsUI { get; private set; }
        public GameObject DialoguePanel { get; private set; }

        private void Awake()
        {
            // 싱글톤 패턴
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            CacheUIObjects();
        }

        private void CacheUIObjects()
        {
            // Canvas 루트 기준으로 하위 UI 찾기
            Transform canvas = GameObject.Find("Canvas")?.transform;

            if (canvas == null)
            {
                Debug.LogError("[UIManager] Canvas 오브젝트를 찾을 수 없습니다.");
                return;
            }

            // 상태바
            HPbar = canvas.Find("HPbar")?.gameObject;
            MPbar = canvas.Find("MPbar")?.gameObject;
            EXPbar = canvas.Find("EXPbar")?.gameObject;

            // PlayerUI 하위
            Transform playerUI = canvas.Find("PlayerUI");
            if (playerUI != null)
            {
                InventoryPanel = playerUI.Find("InventoryPanel")?.gameObject;
                InventoryTooltip = playerUI.Find("InventoryTooltip")?.gameObject;
                EquipmentPanel = playerUI.Find("EquipmentPanel")?.gameObject;
                StatsUI = playerUI.Find("StatsUI")?.gameObject;
                DialoguePanel = playerUI.Find("DialoguePanel")?.gameObject;
            }
            else
            {
                Debug.LogWarning("[UIManager] PlayerUI 오브젝트를 찾을 수 없습니다.");
            }
        }

        // 공통 UI 열고 닫기
        public void ToggleUI(GameObject uiObj, bool active)
        {
            if (uiObj == null)
            {
                Debug.LogWarning("[UIManager] Toggle하려는 UI가 null입니다.");
                return;
            }

            uiObj.SetActive(active);
        }

        // 예: 인벤토리 토글
        public void ToggleInventory()
        {
            if (InventoryPanel != null)
                InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        }

        // 예: 대화창 열기
        public void ShowDialogue(string npcName)
        {
            if (DialoguePanel != null)
            {
                DialoguePanel.SetActive(true);
                // 필요한 경우 DialoguePanel.GetComponent<DialogueUI>() 등 접근 가능
            }
        }

        public void CloseDialogue()
        {
            if (DialoguePanel != null)
                DialoguePanel.SetActive(false);
        }
    }
}
