using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text levelText;
    

    private PlayerStats player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerStats>();
        if (player != null)
        {
            player.OnStatsChanged += UpdateStats;
            player.OnLevelUp += UpdateStats;
            UpdateStats();
        }
    }

    void UpdateStats()
    {
        if (player == null) return;

        attackText.text = $"공격력: {player.TotalAttack}";
        defenseText.text = $"방어력: {player.TotalDefense}";
        levelText.text = $"레벨: {player.level}";
    }
}
