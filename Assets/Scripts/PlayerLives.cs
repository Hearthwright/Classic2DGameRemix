using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText; // Reference to TextMeshPro UI Componenet
    [Header("Life Settings")]
    public int lives = 3; // Determines the amount of lives the player has (Default = 3)

    [Header("Debug Settings")]
    public bool invincible = false; // Determines whether or not the player is invincible, and thus immune to damage (Degfault = false)

    private SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Player Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If Player collides with an enemy...
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Player has collided with an enemy");
            // Destroy the enemy
            Destroy(collision.gameObject);
            // If player is not invincible
            if (!invincible)
            {
                // Deduct one life
                lives--;
                // Update Lives Text
                livesText.text = "Lives: " + lives;
                //If player runs out of lives...
                if (lives <= 0)
                {
                    // Call for lose Screen
                    sceneController.GameOver();
                }
                Debug.Log("Player has taken damage!");
            }
            else 
            {
                Debug.Log("Player would have taken damage, but is Invincible!");
            }
        }
    }
}
