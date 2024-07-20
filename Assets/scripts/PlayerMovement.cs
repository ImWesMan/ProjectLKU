using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    Vector2 movement;
    public static bool facingRight = false; // Default to true if initially facing right
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD keys
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        movement.y = Input.GetAxisRaw("Vertical") * moveSpeed;

        // Update animator parameters
        animator.SetFloat("Movementx", Mathf.Abs(movement.x));
        animator.SetFloat("Movementy", Mathf.Abs(movement.y));

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Flip the character based on the mouse position
        if (mousePosition.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (mousePosition.x < transform.position.x && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move the character
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    // Method to flip the character
    void Flip()
    {
        facingRight = !facingRight;

        foreach (Transform child in transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX; // Flip the sprite renderer
            }
        }
    }
}
