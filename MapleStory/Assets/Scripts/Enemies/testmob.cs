using UnityEngine;

public class testmob : MonoBehaviour
{
    public MonsterData data;
    public string monsterName;
    private float monsterLevel;
    private float currentHealth;
    private bool isdead = false;

    public MonsterSpawner spawner;


    void Start()
    {
        currentHealth = data.maxHealth;
        monsterName = data.monsterName;
        monsterLevel = data.monsterLevel;
        Die();
    }

    void Die()
    {
        isdead = true;
        if (spawner != null)
        {
            spawner.SpawnAfterDelay(3f);
            
        }
        Destroy(gameObject, 2f);
    }
}
