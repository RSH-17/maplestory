using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NPC/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string npcName;
    [TextArea(3, 5)] public string[] sentences;
}
