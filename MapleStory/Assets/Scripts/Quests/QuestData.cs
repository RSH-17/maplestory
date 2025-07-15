using UnityEngine;

public enum QuestState { NotAccepted, InProgress, Completed }

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/Quest Data")]
public class QuestData : ScriptableObject
{
    public string questId;
    public string title;
    [TextArea] public string description;

    public QuestState state = QuestState.NotAccepted;
}
