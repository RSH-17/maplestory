using UnityEngine;
using System.Collections;
public class testmob : MonoBehaviour
{
    public MonsterData data;
    public string monsterName;
    private float monsterLevel;
    private float currentHealth;
    private bool isdead = false;

    public MonsterSpawner spawner;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = data.maxHealth;
        monsterName = data.monsterName;
        monsterLevel = data.monsterLevel;
        Die();
    }

    void Die()
    {
        
        StartCoroutine(MobDieAimationDelay(4f));


        if (spawner != null)
        {
            spawner.SpawnAfterDelay(7f);

        }
    }

    private IEnumerator MobDieAimationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (animator != null)
        {
            animator.SetTrigger("Die");
            isdead = true;
        }

        yield return null;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        float dieLength = info.length;
        Destroy(gameObject, 0.85f);
    }

    public bool getIsDead()
    {
        return isdead;
    }
}
