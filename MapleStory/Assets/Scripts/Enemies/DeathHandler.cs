using TMPro;
using UnityEngine;
using System.Collections;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float destroyDelay = 0.85f;

    private bool isDead = false;
    private FadeoutHandler fadeoutHandler;
    private HealthHandler health;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        fadeoutHandler = GetComponent<FadeoutHandler>();
    }

    void OnEnable()
    {
        health = GetComponent<HealthHandler>();
        if (health != null)
        {
            health.OnDie += Die;
        }
    }

    void OnDisable()
    {
        if (health != null)
        {
            health.OnDie -= Die;
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        if (animator != null)
            animator.SetTrigger("Die");

        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        fadeoutHandler?.StartFadeOut();
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public bool IsDead() => isDead;
}