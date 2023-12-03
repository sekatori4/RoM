using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public int totalWaves = 10;
    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 2f;
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;

    private int currentWave = 0;
    private List<GameObject>[] previousWaveEnemiesByType;
    private bool isFirstType = true;

    private void Start()
    {
        previousWaveEnemiesByType = new List<GameObject>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            previousWaveEnemiesByType[i] = new List<GameObject>();
        }

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < totalWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            SpawnWave();

            currentWave++;

            // Добавим логику для смены типа врагов каждые 5 волн, начиная со второй волны
            if (currentWave % 5 == 0 && currentWave > 1)
            {
                isFirstType = false;
            }
        }
    }

    private void SpawnWave()
    {
        int enemiesPerWave = 5;
        int enemyTypeIndex = isFirstType ? 0 : Random.Range(1, enemyPrefabs.Length);
        GameObject enemyType = enemyPrefabs[enemyTypeIndex];

        enemiesPerWave += previousWaveEnemiesByType[enemyTypeIndex].Count;
        StartCoroutine(SpawnEnemies(enemyType, enemiesPerWave));
    }

    private IEnumerator SpawnEnemies(GameObject enemyType, int enemiesPerWave)
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Instantiate(enemyType, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
}
