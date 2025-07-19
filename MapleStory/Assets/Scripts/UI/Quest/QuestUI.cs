using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public GameObject questPanel;

    public void ShowQuest(string questName, string description)
    {
        questPanel.SetActive(true);
        // 텍스트 세팅 코드 등
    }

    public void HideQuest()
    {
        questPanel.SetActive(false);
    }
}