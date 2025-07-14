using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI 요소")]
    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;

    private string[] sentences;
    private int index = 0;
    private bool isActive = false;

    public void StartDialogue(DialogueData data)
    {
        if (data == null || data.sentences == null || data.sentences.Length == 0)
        {
            Debug.LogWarning("⚠️ 대사 데이터가 비어 있습니다.");
            return;
        }

        Debug.Log($"🗨️ 대화 시작: {data.npcName}");

        panel.SetActive(true);
        isActive = true;

        nameText.text = data.npcName;
        sentences = data.sentences;
        index = 0;

        ShowSentence();
    }

    public void ShowSentence()
    {
        if (!isActive) return;

        if (index < sentences.Length)
        {
            dialogueText.text = sentences[index];
            index++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("🛑 대화 종료");
        nameText.text = "";
        dialogueText.text = "";
        panel.SetActive(false);
        isActive = false;
    }

    void Start()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowSentence);
        }
        else
        {
            Debug.LogWarning("❌ 다음 버튼이 연결되어 있지 않습니다.");
        }

        panel.SetActive(false); // 시작 시 UI 비활성화
    }
}
