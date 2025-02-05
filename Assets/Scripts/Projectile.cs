using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float projectileSpeed = 5f; // Determines how fast the projectile moves (Default = 5f)
    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("Points").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    // Projectile Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a projectile hits an enemy...
        if(collision.gameObject.tag == "Enemy")
        {
            // Destroy the enemy
            Destroy(collision.gameObject);
            // Earn Points
            pointManager.UpdateScore(50);
            // Destroy the projectile
            Destroy(gameObject);
        }
        // If the projectile hits a boundary...
        if(collision.gameObject.tag == "Upper Boundary" || collision.gameObject.tag == "Side Boundary")
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
