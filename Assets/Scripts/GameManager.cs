using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public Transform[] spawnPoints;

    private float spawnInterval = 2f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject enemyPrefab = Random.Range(0, 2) == 0 ? blackEnemyPrefab : whiteEnemyPrefab;
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
