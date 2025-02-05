using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab that will be fired

    // Update is called once per frame
    void Update()
    {
        // If the player presses Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn a projectile at the player's current position
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
