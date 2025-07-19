using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class LocalSpawnerManager : MonoBehaviour
{
    //역할 : 몬스터 상태관리, 몬스터 스폰
    private bool isDead { get; set; } = true;
    private GameObject currentMonster;

    void OnEnable()
    {
        WorldSpawnManager.trySpawn += SpawnRequest;
    }

    void OnDisable()
    {
        WorldSpawnManager.trySpawn -= SpawnRequest;
    }


    //테스트용으로 함수 매개변수 뺌
    public void SpawnRequest(GameObject monster)
    {
        if (isDead)
        {
            currentMonster = Instantiate(monster, transform.position, quaternion.identity);
            DeathHandler death = currentMonster.GetComponent<DeathHandler>();

            if (death != null)
                death.OnDie += MonsterDeathHandler;
        }
        else return;
    }

    void MonsterDeathHandler()
    {
        isDead = true;
        if (currentMonster != null)
        {
            currentMonster.GetComponent<DeathHandler>().OnDie -= MonsterDeathHandler;
            currentMonster = null;
        }
    }


    
    
}
