using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestData quest;

    public void OfferQuest()
    {
        if (quest == null)
        {
            Debug.LogWarning("❌ QuestGiver에 퀘스트가 연결되지 않았습니다!");
            return;
        }

        if (quest.state == QuestState.NotAccepted)
        {
            QuestManager.Instance.AddQuest(quest);
            Debug.Log($"🆕 퀘스트 수락: {quest.title}");
        }
        else if (quest.state == QuestState.InProgress)
        {
            Debug.Log("⚠️ 이미 수락한 퀘스트입니다.");
        }
        else if (quest.state == QuestState.Completed)
        {
            Debug.Log("🎉 이미 완료한 퀘스트입니다.");
        }
    }
}
