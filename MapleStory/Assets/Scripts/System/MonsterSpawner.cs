using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour
{
    [Header("스폰설정")]
    public GameObject monsterPrefab;
    public Vector2 spawnpoint = new Vector2(0, 0);


    void Start()
    {
        SpawnMonster();
    }

    void SpawnMonster()
    {
        GameObject obj = Instantiate(monsterPrefab, spawnpoint, Quaternion.identity);
        testmob mob = obj.GetComponent<testmob>();
        if (mob != null)
        {
            mob.spawner = this;
        }

    }

    public void SpawnAfterDelay(float delay)
    {
        StartCoroutine(SpawnCoroutine(delay));
    }

    private IEnumerator SpawnCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnMonster();
    }

}
