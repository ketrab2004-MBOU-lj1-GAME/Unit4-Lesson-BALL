using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;

    public int enemyCount = 0;
    public int waveCount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount); //spawn first wave
    }

    void SpawnEnemyWave(int waveSize)
    {
        Instantiate(powerupPrefab, GenSpawnPos() - new Vector3(0, 5.9f, 0), powerupPrefab.transform.rotation, transform);
        //create powerup before enemies at genSpawnPos - extra height for enemies, standard rotation and inside spawnManager
        
        for (int i = 0; i < waveSize; i++)
        {
            Instantiate(spawnPrefab, GenSpawnPos(), spawnPrefab.transform.rotation, transform);
            //create enemie at genSpawnPos, prefab rotation and child of spawnManager
        }
        
        waveCount++; //increase waveCount
    }
    Vector3 GenSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); //get random X
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); //get random Z
        return new Vector3(spawnPosX, 6, spawnPosZ); //return random X and Z with standard height
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; //get length/amount of objects with type Enemy
        if (enemyCount <= 0)
        {
            SpawnEnemyWave(waveCount);
            //if no enemies or negative enemies left spawn new wave
        }
    }
}
