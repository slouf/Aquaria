using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Basic life script for player
public class PlayerLife : MonoBehaviour
{

    // For animations
    private Animator anim;
    // Rigidbody component for player
    private Rigidbody2D rb;

    // Audio effect for death (edit in unity editor)
    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        // self explanatory
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();  
    }
    // When trap comes in contact with player, die
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

    }
    
    // Called when collided with trap
    private void Die()
    {
        // Play death sound effect
        deathSoundEffect.Play();
        // Set body type of rigidbody 2d to static, meaning player cant move at all
        rb.bodyType = RigidbodyType2D.Static;
        // set the animation state to "death"
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        // Load the scene again from beginning 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
