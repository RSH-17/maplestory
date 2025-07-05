using UnityEngine;

public class testmob : MonoBehaviour
{
    public MonsterData data;
    public string monsterName;
    private float monsterLevel;
    private float currentHealth;


    void Start()
    {
        currentHealth = data.maxHealth;
        monsterName = data.monsterName;
        monsterLevel = data.monsterLevel;
        Debug.Log($"now health:{currentHealth}");
        Debug.Log($"name:{monsterName}");
        Debug.Log($"level:{monsterLevel}");
    }

    
    void Update()
    {
        
    }
}
