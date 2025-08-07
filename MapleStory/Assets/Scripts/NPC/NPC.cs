using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueData dialogueData;
    public QuestGiver questGiver;

    private DialogueUI dialogueUI;

    void Start()
    {
        dialogueUI = FindAnyObjectByType<DialogueUI>();
    }

    void OnMouseDown()
    {
        if (dialogueUI != null && dialogueData != null)
        {
            dialogueUI.StartDialogue(dialogueData, questGiver);
        }
    }
}

