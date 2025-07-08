using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Slider hpSlider;
    public Slider mpSlider;
    public Slider expSlider;

    public TMP_Text hpText;
    public TMP_Text mpText;
    public TMP_Text expText;

    public PlayerStats playerStats;

    void Start()
    {
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats가 연결되지 않았습니다!");
            return;
        }

        playerStats.OnStatsChanged += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        // HP
        hpSlider.value = playerStats.hp.GetRatio();
        hpText.text = playerStats.hp.GetDisplayString();

        // MP
        mpSlider.value = playerStats.mp.GetRatio();
        mpText.text = playerStats.mp.GetDisplayString();

        // EXP
        expSlider.value = playerStats.exp.GetRatio();
        expText.text = playerStats.exp.GetDisplayString();
    }
}
