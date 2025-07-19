using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    private Dictionary<string, QuestData> quests = new Dictionary<string, QuestData>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddQuest(QuestData quest)
    {
        if (!quests.ContainsKey(quest.questId))
        {
            quests.Add(quest.questId, quest);
            quest.state = QuestState.InProgress;
            Debug.Log($"🆕 퀘스트 수락: {quest.title}");
        }
    }

    public void CompleteQuest(string questId)
    {
        if (quests.ContainsKey(questId))
        {
            quests[questId].state = QuestState.Completed;
            Debug.Log($"✅ 퀘스트 완료: {quests[questId].title}");
        }
    }

    public bool HasQuest(string questId)
    {
        return quests.ContainsKey(questId);
    }

    public QuestData GetQuest(string questId)
    {
        return quests.TryGetValue(questId, out var quest) ? quest : null;
    }
}
