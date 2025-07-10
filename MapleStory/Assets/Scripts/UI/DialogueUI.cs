using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;

    private string[] sentences;
    private int index = 0;

    public void StartDialogue(DialogueData data)
    {
        Debug.Log($"🗨️ StartDialogue 실행됨: {data.npcName}");
        panel.SetActive(true);
        nameText.text = data.npcName;
        sentences = data.sentences;
        index = 0;
        ShowSentence();
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
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        nameText.text = "";
        dialogueText.text = "";
        panel.SetActive(false); // 전체 UI 숨김
    }

    void Start()
    {
        nextButton.onClick.AddListener(ShowSentence);
        EndDialogue(); // 이건 내부 내용만 숨김
    }
}
