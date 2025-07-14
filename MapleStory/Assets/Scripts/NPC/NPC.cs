using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueData dialogueData;

    DialogueUI dialogueUI;

    void Start()
    {
        dialogueUI = FindAnyObjectByType<DialogueUI>();
        if (dialogueUI == null)
        {
            Debug.LogWarning("❌ DialogueUI를 찾지 못했습니다.");
        }
    }

    void OnMouseDown()
{
    Debug.Log("🖱️ NPC 클릭됨!");

    if (dialogueUI != null && dialogueData != null)
    {
        dialogueUI.StartDialogue(dialogueData);
    }
    else
    {
        Debug.LogWarning("❌ dialogueUI 또는 dialogueData가 null입니다!");
    }
}
}
