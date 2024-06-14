using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject whiteEnemyPrefab;
    public GameObject blackEnemyPrefab;
    public float spawnRate = 2f;
    public float spawnDistance = 50f; 

    private float nextSpawnTime;

    void Update()
    {
        MoveSpawner();
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void MoveSpawner()
    {
        transform.position += Vector3.forward * Time.deltaTime * Camera.main.GetComponent<CameraController>().speed;
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(-10f, 10f); 
        Vector3 spawnPosition = new Vector3(spawnX, 0, transform.position.z + spawnDistance);

        if (Random.value > 0.5f)
        {
            Instantiate(whiteEnemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(blackEnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

