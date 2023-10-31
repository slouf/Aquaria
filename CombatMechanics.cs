using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMechanics : MonoBehaviour
{

    public int HP = 20;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    
    public int attackDamage = 5;
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;
    [SerializeField] private float knockbackX;
    [SerializeField] private float knockbackY;

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && !PlayerMovement.isSwimming)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
