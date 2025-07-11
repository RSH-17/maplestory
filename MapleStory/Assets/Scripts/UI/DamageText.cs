using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI), typeof(FadeoutHandler))]
public class DamageText : MonoBehaviour
{
    [Header("움직임 설정")]
    public float moveSpeed = 30f;

    private TextMeshProUGUI text;
    private RectTransform rectTransform;
    private FadeoutHandler fadeout;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        fadeout = GetComponent<FadeoutHandler>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
    }

    public void setDamageText(int damage)
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();

        text.text = damage.ToString();
        fadeout.StartFadeOut();
    }
}
