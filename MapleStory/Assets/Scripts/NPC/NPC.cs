using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueData dialogue;
    public DialogueUI dialogueUI; // 👈 수동 연결용

    void OnMouseDown()
    {
        Debug.Log("🖱️ NPC 클릭됨");

        if (dialogueUI != null)
        {
            dialogueUI.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogWarning("❌ dialogueUI가 연결되지 않았습니다!");
        }
    }
}
