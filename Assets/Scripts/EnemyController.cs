using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    public float moveSpeed; // Determines how fast the aliens move horizontally across the screen 
    public float shiftAmount; // Determines how far aliens shift downward after bumping either of the side boundaries

    // Update is called once per frame
    void Update()
    {
        // The Aliens will move right at a constant pace determined by moveSpeed every second
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // If the number of child objects is 0
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    // Enemy collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If enemies collide with boundary
        if(collision.gameObject.tag == "Side Boundary")
        {
            //Shift enemies downward
            transform.position = new Vector3 (transform.position.x, transform.position.y - shiftAmount, transform.position.z);
            // Have enemies move in the opposite direction by multiplying move speed by negative 1
            moveSpeed *= -1;
        }
    }
}
