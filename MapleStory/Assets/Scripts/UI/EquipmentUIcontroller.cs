using UnityEngine;
using UnityEngine.InputSystem;

public class EquipmentUIController : MonoBehaviour{
    public GameObject equipmentPanel;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            equipmentPanel.SetActive(!equipmentPanel.activeSelf);
        }
    }
}