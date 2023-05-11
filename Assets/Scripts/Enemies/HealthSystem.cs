using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject spawnOrb;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
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
        Destroy(gameObject);
        Instantiate(spawnOrb, transform.position, transform.rotation);
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
