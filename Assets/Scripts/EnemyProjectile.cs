using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float projectileSpeed = 5f; // Determines how fast the projectile moves (Default = 5f)

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * projectileSpeed * Time.deltaTime);
    }

    // Projectile Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the projectile hits a boundary...
        if(collision.gameObject.tag == "Lower Boundary")
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
