using UnityEngine;

public abstract class SkillEffect : ScriptableObject
{
    public abstract void Apply(GameObject user);
}

[CreateAssetMenu]
public class DamageEffect : SkillEffect
{
    public int baseDamage;
    public int coefficient;

    // 원형 스킬인 경우
    public float range;

    public override void Apply(GameObject user)
    {
        PlayerStats stats = user.GetComponent<PlayerStats>();
        int damage = (int)(baseDamage + stats.TotalAttack * coefficient); // 우선 int로 형 변환

        // 주변 적에게 데미지 주기 원형
        Collider2D[] enemies = Physics2D.OverlapCircleAll(user.transform.position, range);
        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent<IDamageable>(out var health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}

[CreateAssetMenu]
public class BuffEffect : SkillEffect
{
    public int buffAmount;
    public int duration;

    public override void Apply(GameObject user)
    {
        if (user.TryGetComponent<PlayerStats>(out var stats))
        {
            stats.ApplyBuff(buffAmount, duration);
        }
    }
}