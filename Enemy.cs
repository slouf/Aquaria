using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


private SpriteRenderer spriteR;
private Rigidbody2D rb;
private Animator anim;
private BoxCollider2D coll;
private Transform tr;
public class Enemy : MonoBehaviour
{
    public int maxHealth = 20;
    
    private int currentHealth;
    


    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(Knockback(Mathf.Sign(tr.position.x - player.transform.position.x) * knockbackX, knockbackY));

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
    }

    public IEnumerator Knockback(float x, float y)
    {
        FollowPlayer.beingKocked = true;
        rb.velocity = new Vector2(x, y);

        float start = Time.time;

        while (Time.time < start + FollowPlayer.knockbackDuration)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.99f, rb.velocity.y * 0.99f);
            yield return new WaitForSeconds(0.1f);
        }
        FollowPlayer.beingKocked = false;
    }
}
