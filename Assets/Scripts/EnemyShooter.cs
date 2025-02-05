using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab that will be fired
    [Header("Life Settings")]
    public float spawnChance = 0.15f; // The percent chance every second that an enemy will shoot a projectile (Default = 0.15f or 15%)
    public float spawnDelay = 2f; // The minimum amount of time (in seconds) between shots fired

    private float lastSpawnTime; // Keeps track of the last spawn time for a projectile

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time; // Initialize last spawn time
    }

    // Update is called once per frame
    void Update()
    {
        // If enough time has passed to allow for another projectile to be fired...
        if (Time.time - lastSpawnTime >= spawnDelay)
        {
            // Roll to see if a projectile will be fired
            if (Random.value <= spawnChance)
            {
                // Spawn a projectile at the enemy's current position
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }
            // Update the last spawn time to the current time
            lastSpawnTime = Time.time;
        }
    }
}
