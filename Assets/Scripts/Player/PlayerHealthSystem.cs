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

    [SerializeField] private int currentHealth;
    private int healthRegenValue;
    private bool healthRegenIsEnabled;
    private float time;

    private void Start()
    {
        healthRegenValue = 0;
        time = 1;

        deathPanel.SetActive(false);
        currentHealth = maxHealth;

        healthRegenIsEnabled = false;
        StartCoroutine(HealthRegenDelay());
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

    private IEnumerator HealthRegenDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            HealthRegen();
        }
    }

    public void HealthRegen()
    {
        if (healthRegenIsEnabled)
        {
            IncreaseCurrentHealth(healthRegenValue);
        }
    }

    public void IncreaseHealthRegenValue(int value)
    {
        healthRegenValue += value;
    }

    public void EnableHealthRegen()
    {
        healthRegenIsEnabled = true;
    }

    public void IncreaseMaxHealth(int value)
    {
        maxHealth += value;
        IncreaseCurrentHealth(value);
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
