using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int waveNumber = 1;
    public int enemiesCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        if (enemiesCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    private Vector3 GenerateRandomPosision()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int ii = 0; ii < enemiesToSpawn; ii++)
            Instantiate(enemyPrefab, GenerateRandomPosision(), enemyPrefab.transform.rotation);
    }
    
    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateRandomPosision(), powerupPrefab.transform.rotation);
    }
}
