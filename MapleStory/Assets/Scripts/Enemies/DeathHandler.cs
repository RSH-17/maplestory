using TMPro;
using UnityEngine;
using System.Collections;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float destroyDelay = 0.85f;

    private bool isDead = false;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
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
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public bool IsDead() => isDead;
}