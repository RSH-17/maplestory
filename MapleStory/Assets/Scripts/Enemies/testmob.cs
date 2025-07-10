using UnityEngine;
using System.Collections;
public class testmob : MonoBehaviour
{
    public MonsterData data;
    public string monsterName;
    public GameObject DamageTextPrefab;

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

        StartCoroutine(DamageOverTime());

    }

    void Die()
    {
        StartCoroutine(MobDieAimationDelay(0f));


        if (spawner != null)
        {
            spawner.SpawnAfterDelay(3f);

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

    private IEnumerator DamageOverTime()
    {
        while (currentHealth > 0)
        {
            int damage = Random.Range(1, 6);
            TakeDamage(damage);
            Debug.Log($"{currentHealth}");
            if (currentHealth <= 0)
            {
                Die();
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public bool getIsDead()
    {
        return isdead;
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        ShowDamageText(dmg);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ShowDamageText(int damage)
    {
        GameObject dt = Instantiate(DamageTextPrefab, Vector3.zero, Quaternion.identity);
        dt.transform.SetParent(GameObject.Find("Canvas").transform,false);
        dt.transform.position = transform.position + Vector3.up * 1f;
        dt.GetComponent<DamageText>().setDamageText(damage);
    }
    
    
}
