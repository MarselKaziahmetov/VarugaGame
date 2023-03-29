using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject spawnOrb;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
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
        Destroy(gameObject);
        Instantiate(spawnOrb, transform.position, transform.rotation);
        PlayerLevel.instance.KillsCount++;
    }

    public int GetHealthValue()
    {
        return currentHealth;
    }
    public int GetMaxHealthValue()
    {
        return maxHealth;
    }
}
