using System;
using System.Data;
using UnityEngine;
using System.Collections;

public class WorldSpawnManager : MonoBehaviour
{
    public GameObject MonsterPrefab;
    public static event Action<GameObject> trySpawn;
    [SerializeField] private float waveDelay = 7f;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            trySpawn?.Invoke(MonsterPrefab);
            yield return new WaitForSeconds(waveDelay);
        }
    }
}