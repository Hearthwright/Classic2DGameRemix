using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab; // The Prefab of the enemy that will be spawned
    public Transform spawnPoint; // The position where enemies will spawn from
    public float spawnInterval = 5f; // How often (in seconds) enemies should spawn
    public int maxEnemies = 20; // Determines the amount of enemy prefabs that will spawned

    private int enemiesSpawned = 0; // Tracks how many enemy prefabs have been spawned


    // Start is called before the first frame update
    void Start()
    {
        // Start the enemy spawning coroutine
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn enemies at regular intervals
    IEnumerator SpawnEnemies()
    {
        // Spawn enemies until the maximum is reached
        while (enemiesSpawned < maxEnemies)
        {
            // Instantiate a new enemy at the spawn position with default rotation
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Incremenets enemiesSpawned
            enemiesSpawned++;

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
        // Once the max number of enemies is spawned, stop the spawner
        Debug.Log("All enemies have been spawned.");
    }
}
