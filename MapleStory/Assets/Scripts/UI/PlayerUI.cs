using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem; // Input System용

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

    [Header("Potion Data")]
    public PotionData hpPotion;
    public PotionData mpPotion;

    float currentHP;
    float maxHP = 100f;
    float currentMP;
    float maxMP = 60f;

    void Start()
    {
        currentHP = 70f;
        currentMP = 40f;
        UpdateHP(currentHP, maxHP);
        UpdateMP(currentMP, maxMP);
        UpdateEXP(150, 150);
    }

    void Update()
    {
        // 체력 포션 - H 키
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            UsePotion(hpPotion);
        }

        // 마나 포션 - M 키
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            UsePotion(mpPotion);
        }
    }

    public void UsePotion(PotionData potion)
    {
        if (potion == null) return;

        switch (potion.potionType)
        {
            case PotionType.HP:
                currentHP = Mathf.Min(currentHP + potion.healAmount, maxHP);
                UpdateHP(currentHP, maxHP);
                break;

            case PotionType.MP:
                currentMP = Mathf.Min(currentMP + potion.healAmount, maxMP);
                UpdateMP(currentMP, maxMP);
                break;
        }

        Debug.Log($"{potion.potionName} 사용됨! {potion.healAmount} 회복");
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
