using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankerSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab; // The Prefab of the enemy that will be spawned
    public float spawnInterval = 5f; // How often (in seconds) enemies should spawn
    public int maxEnemies = 20; // Determines the amount of enemy prefabs that will spawned

    private int enemiesSpawned = 0; // Tracks how many enemy prefabs have been spawned

    [Header("Spawnpoint Settings")]
    public float minY = -5f; // The minimum Y position where enemies can spawn (Default = -5f)
    public float maxY = -3f; // The maximum Y position where enemies can spawn (Default = -3f)
    public float spawnXPosition = 10f; // The absolute value of the X Position where enemies will spawn (Default = 10f)

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
            // Randomize the Y position between minY and maxY
            float randomY = Random.Range(minY, maxY);

            // Randomly select one of the X positions (-spawnXPosition or +spawnXPosition)
            float spawnX = Random.value < 0.5f ? -spawnXPosition : spawnXPosition;

            // Determine if the spawn is on the right side of the screen (positive X)
            bool isRight = spawnX > 0;

            // Instantiate the enemy at the chosen position
            Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Flip the rotation if the spawn is on the right side
            if (isRight)
            {
                // Flip the enemy's rotation on the Z axis (180 degrees)
                enemy.transform.Rotate(0f, 0f, 180f);
            }

            // Incremenets enemiesSpawned
            enemiesSpawned++;

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
        // Once the max number of enemies is spawned, stop the spawner
        Debug.Log("All enemies have been spawned.");
    }
}
