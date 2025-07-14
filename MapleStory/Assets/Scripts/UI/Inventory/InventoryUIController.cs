using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryPanel;

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }
    }
}
