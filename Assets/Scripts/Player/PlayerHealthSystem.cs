using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Animator deathPanelAnim;
    [SerializeField] private Timer timer;

    private int currentHealth;

    private void Start()
    {
        deathPanel.SetActive(false);
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
    public void IncreaseCurrentHealth(int manaValue)
    {
        if (currentHealth + manaValue <= maxHealth)
        {
            currentHealth += manaValue;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHealth(int manaValue)
    {
        maxHealth = manaValue;
    }

    private void Die()
    {
        timer.timerIsActivated = false;
        deathPanel.SetActive(true);
        deathPanelAnim.SetBool("IsLightning", true);
        Destroy(gameObject);
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
