using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public Stat hp = new Stat(100);
    public Stat mp = new Stat(50);
    public Stat exp = new Stat(100);

    public float speed = 3f;
    public float jumpPower = 10f;

    public int level = 1;

    public event Action OnStatsChanged;
    public event Action OnLevelUp;

    void Start()
    {
        // 시작 시 UI 갱신
        OnStatsChanged?.Invoke();
    }

    // 데미지 처리
    public void TakeDamage(int damage)
    {
        hp.Decrease(damage);
        OnStatsChanged?.Invoke();
    }

    // 회복 처리 (포션 등)
    public void UsePotion(int hpAmount, int mpAmount)
    {
        hp.Increase(hpAmount);
        mp.Increase(mpAmount);
        OnStatsChanged?.Invoke();
    }

    // 경험치 획득 및 레벨업 처리
    public void GainExp(int amount)
    {
        exp.Increase(amount);

        while (exp.Current >= exp.Max)
        {
            exp.Set(exp.Current - exp.Max);
            LevelUp();
        }

        OnStatsChanged?.Invoke();
    }

    private void LevelUp()
    {
        level++;
        hp.IncreaseMax(20);   // HP 최대치 +20
        mp.IncreaseMax(10);   // MP 최대치 +10
        exp.IncreaseMax(50);  // EXP 최대치 +50

        hp.RestoreFull();
        mp.RestoreFull();

        Debug.Log($"레벨업! 현재 레벨: {level}");
        OnLevelUp?.Invoke();
        OnStatsChanged?.Invoke();
    }
    public int baseAttack = 5;
    public int baseDefense = 3;
    private int bonusAttack = 0;
    private int bonusDefense = 0;

    public int TotalAttack => baseAttack + bonusAttack;
    public int TotalDefense => baseDefense + bonusDefense;

    public void Equip(ItemData item)
    {
        if (item is EquipmentItemData equip)
        {
            bonusAttack += equip.attackPower;
            bonusDefense += equip.defensePower;
            OnStatsChanged?.Invoke();
        }
    }

    public void Unequip(ItemData item)
    {
        if (item is EquipmentItemData equip)
        {
            bonusAttack -= equip.attackPower;
            bonusDefense -= equip.defensePower;
            OnStatsChanged?.Invoke();
        }
    }
    
    public void ApplyBuff(int buffAmount, int duration)
    {

    }
}
