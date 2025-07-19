using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public GameObject tooltipPanel;
    public TMP_Text nameText;
    public TMP_Text descText;

    void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            // 마우스 따라다니게
            Vector2 pos = Input.mousePosition;
            tooltipPanel.transform.position = pos + new Vector2(150f, -50f);
        }
    }

    public void Show(string name, string desc)
    {
        nameText.text = name;
        descText.text = desc;
        tooltipPanel.SetActive(true);
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);
    }
}
