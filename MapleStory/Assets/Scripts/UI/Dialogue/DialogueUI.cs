using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;
    public Button acceptButton; // ✅ 수락 버튼 추가

    private string[] sentences;
    private int index = 0;
    private QuestGiver currentQuestGiver;

    public void StartDialogue(DialogueData data, QuestGiver questGiver = null)
    {
        panel.SetActive(true);
        nameText.text = data.npcName;
        sentences = data.sentences;
        index = 0;
        currentQuestGiver = questGiver;

        dialogueText.text = sentences[index];
        index++;

        // 버튼 활성화 설정
        nextButton.gameObject.SetActive(true);
        acceptButton.gameObject.SetActive(false);
    }

    public void ShowSentence()
    {
        if (index < sentences.Length)
        {
            dialogueText.text = sentences[index];
            index++;
        }
        else
        {
            // 마지막 문장 → 수락 버튼이 필요한 경우
            if (currentQuestGiver != null && currentQuestGiver.quest != null && currentQuestGiver.quest.state == QuestState.NotAccepted)
            {
                acceptButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(false);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void AcceptQuest()
    {
        if (currentQuestGiver != null)
        {
            currentQuestGiver.OfferQuest();
        }
        EndDialogue();
    }

    public void EndDialogue()
    {
        panel.SetActive(false);
        nameText.text = "";
        dialogueText.text = "";
        index = 0;
        currentQuestGiver = null;
    }

    void Start()
    {
        nextButton.onClick.AddListener(ShowSentence);
        acceptButton.onClick.AddListener(AcceptQuest);
        EndDialogue();
    }
}
