using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NPC/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string npcName;
    [TextArea] public string[] sentences;
}
