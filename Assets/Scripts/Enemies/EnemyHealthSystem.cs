using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private float deathTime;

    private float currentHealth;
    private EnemiesMovement enemiesMovement;
    private EnemyDamager enemyDamager;
    private DropSystem dropSystem;
    private Collider2D collider2d;

    private void Start()
    {
        currentHealth = maxHealth;

        enemiesMovement = GetComponent<EnemiesMovement>();
        enemyDamager = GetComponent<EnemyDamager>();
        collider2d = GetComponent<Collider2D>();
        dropSystem = GetComponent<DropSystem>();
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, deathTime);

        animator.SetBool("isDead", true);
        enemiesMovement.enabled = false;
        enemyDamager.enabled = false;
        collider2d.enabled = false;

        dropSystem.DropItems();

        PlayerLevel.instance.KillsCount++;
    }

    public float GetHealthValue()
    {
        return currentHealth;
    }
    public float GetMaxHealthValue()
    {
        return maxHealth;
    }
}
