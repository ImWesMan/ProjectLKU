using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private GameObject player;
    public bool facingleft = true;
    public Animator animator;
    [SerializeField]
    public float speed;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Movementx", Mathf.Abs(movement.x));
        animator.SetFloat("Movementy", Mathf.Abs(movement.y));
        Swarm();
    }

    void Swarm()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (transform.position.x < (player.transform.position.x - 0.7f) && facingleft)
        {
            movement.x = 1;
            movement.y = 1;
            Flip();
        }
        else if (transform.position.x > (player.transform.position.x + 0.7f) && !facingleft)
        {
            movement.x = 1;
            movement.y = 1;
            Flip();
        }
        else if (distanceToPlayer <= 0.7f)
        {
            movement.x = 0;
            movement.y = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        facingleft = !facingleft;

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
