using System;
using NUnit.Framework;
using UnityEngine;

public class HealthHandler : MonoBehaviour, IDamageable
{
    [SerializeField] private MonsterData monsterData;
    private float currentHealth;
    private bool isDead = false;

    public event Action<int> OnDamaged;
    public event Action OnDie;

    private DeathHandler death;
    private DamageTextHandler damageText;

    void Awake()
    {
        currentHealth = monsterData.maxHealth;
        death = GetComponent<DeathHandler>();
        damageText = GetComponent<DamageTextHandler>();
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        currentHealth -= dmg;
        OnDamaged?.Invoke(dmg);

        if (currentHealth <= 0)
        {
            isDead = true;
            OnDie?.Invoke();
        }
    }

    public bool IsDead() => isDead;
}
