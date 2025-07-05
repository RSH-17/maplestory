using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

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

    float currentHP;
    float currentMP;
    float currentEXP;
    float maxHP = 100f;
    float maxMP = 100f;
    float maxEXP = 100f;

    void Start()
    {
        currentHP = 70f;
        currentMP = 60f;
        currentEXP = 100f;

        UpdateHP(currentHP, maxHP);
        UpdateMP(currentMP, maxMP);
        UpdateEXP(currentEXP, maxEXP);
    }

    void Update()
    {

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            UseHealthPotion();
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            UseManaPotion();
        }
    }

    public void UseHealthPotion()
    {
        float healAmount = 30f;
        currentHP = Mathf.Min(currentHP + healAmount, maxHP);
        UpdateHP(currentHP, maxHP);
        Debug.Log("체력 포션 사용됨!");
    }
    public void UseManaPotion()
    {
        float recoverAmount = 20f;
        currentMP = Mathf.Min(currentMP + recoverAmount, maxMP);
        UpdateMP(currentMP, maxMP);
        Debug.Log("마나 포션 사용됨!");
    }

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
}
