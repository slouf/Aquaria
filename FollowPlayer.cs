using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Follow Player script for enemies
public class FollowPlayer : MonoBehaviour
{
    // How sprite is rendered
    private SpriteRenderer spriteR;
    // 2D Physics component
    private Rigidbody2D rb;
    // Animator component
    private Animator anim;
    // 2D Hitboxes component
    private BoxCollider2D coll;
    // Allows to change size position and rotation (innate)
    private Transform tr;

    // Direction enemy is facing
    private float directionX;

    // Layer Mask for anything that counts as jumpable ground (set in unity editor)
    [SerializeField] private LayerMask jumpableGround;

    // Movement speed for enemy (set in unity editor)
    [SerializeField] private float moveSpeed = 0.00001f;
    // How high the enemy jumps (set in unity editor)
    [SerializeField] private float jumpForce = 6f;
    // Reference to the player that the enemy is following (set in unity editor)
    [SerializeField] private GameObject player;
    
    // How long the knockback duration lasts
    public static float knockbackDuration = 1.0f;
    // Boolean for if enemy is being knocked back
    public static bool beingKocked;


    private void Start()
    {
        // References
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       spriteR = GetComponent<SpriteRenderer>();
       coll = GetComponent<BoxCollider2D>();
       tr = GetComponent<Transform>();
    }

    private void Update()
    {

        // If the enemy isn't being knocked back, start to follow player
        if (!beingKocked)
        {
            // Set direction of enemy relative to the player's current position
            directionX = Mathf.Sign(player.transform.position.x - tr.position.x);
            // Set velocity towards player
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

            // If the player's y value is greater than 0.3 than the enemy, and the enemy is on the floor, jump
            if (player.transform.position.y > tr.position.y + 0.3 && IsGrounded() && Mathf.Abs(player.transform.position.x - tr.position.x) < 6)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        


        // Animation gets called every frame
        UpdateAnimationState();
    }

    // Checks if enemy is grounded 
    private bool IsGrounded()
    {
        // Collision boundaries
        var bounds = coll.bounds;
        // Size of boundaries
        var size = bounds.size;
        size.x -= 1;
        // Returns true/false if boundaries collide with enemy
        return Physics2D.BoxCast(bounds.center, size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdateAnimationState()
    {
        // Flips the sprite depending on where the enemy is moving towards
        switch (directionX)
        {
            case > 0f:
                spriteR.flipX = false;
                break;
            case < 0f:
                spriteR.flipX = true;
                break;
        }
    }

    
}
