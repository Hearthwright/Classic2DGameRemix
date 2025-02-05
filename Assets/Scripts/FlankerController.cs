using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankerController : MonoBehaviour
{
    [Header("Flanking Enemy Movement Settings")]
    public float moveSpeed; // Determines how fast the aliens move horizontally across the screen 
    private bool onScreen = false; // Determines if the flanking enemy has passed one boundary and officialy enterd the play area (Default False)

    // Update is called once per frame
    void Update()
    {
        // The Aliens will move right at a constant pace determined by moveSpeed every second
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    // Enemy collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If enemies collide with boundary
        if(collision.gameObject.tag == "Side Boundary")
        {
            // If the enemy has not yet passed one boundary...
            if (!onScreen)
            {
                onScreen = true;
            }
            // Otherwise...
            else
            {
                // Have enemies move in the opposite direction by multiplying move speed by negative 1
                moveSpeed *= -1;

                // Flip the object visually by reversing its X scale
                Vector3 localScale = transform.localScale;
                localScale.x *= -1; // Inverts the x-axis scale (flips the object)
                transform.localScale = localScale;
            }
        }
    }
}
