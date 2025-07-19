
using UnityEngine;
using TMPro;

public class StatUI : MonoBehaviour
{
    [Header("스탯 텍스트")]
    public TMP_Text hpText;
    public TMP_Text mpText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text levelText;

    public void UpdateStats(PlayerStats stats)
    {
        if (stats == null) return;

        hpText.text = $"HP: {stats.hp.GetDisplayString()}";
        mpText.text = $"MP: {stats.mp.GetDisplayString()}";
        attackText.text = $"공격력: {stats.TotalAttack}";
        defenseText.text = $"방어력: {stats.TotalDefense}";
        levelText.text = $"레벨: {stats.level}";
    }
}
