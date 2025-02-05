using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to TextMeshPro UI Componenet
    [Header("Score Settings")]
    public int score = 0; // Tracks the player's current score

    // Start is called before the first frame update
    void Start()
    {
        // Sets score text to initial value at the start of the game
        scoreText.text = "Score: " + score;
    }

    // Incremenents score by points and updates the TMPro object
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
