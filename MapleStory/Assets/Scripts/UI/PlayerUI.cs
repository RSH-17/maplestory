using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("Bars")]
    public Slider hpSlider;
    public Slider mpSlider;
    public Slider expSlider;

    [Header("Text")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI expText;

    public void UpdateHP(float current, float max)
    {
        hpSlider.value = current / max;
        hpText.text = $"{(int)current} / {(int)max}";
    }

    public void UpdateMP(float current, float max)
    {
        mpSlider.value = current / max;
        mpText.text = $"{(int)current} / {(int)max}";
    }

    public void UpdateEXP(float current, float max)
    {
        expSlider.value = current / max;
        expText.text = $"{(int)current} / {(int)max}";
    }

    void Start()
    {
        UpdateHP(70, 100);
        UpdateMP(60, 60);
        UpdateEXP(150, 150);
    }
}
