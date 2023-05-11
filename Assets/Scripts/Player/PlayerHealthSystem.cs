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
    [SerializeField] private SpriteRenderer sprite;

    private int currentHealth;
    private int healthRegenValue;
    private bool healthRegenIsEnabled;
    private float time;
    private bool isInvicible;
    private Color defaultColor;

    private void Start()
    {
        healthRegenValue = 0;
        time = 1;
        isInvicible = false;

        deathPanel.SetActive(false);
        currentHealth = maxHealth;
        defaultColor = sprite.color;

        healthRegenIsEnabled = false;
        StartCoroutine(HealthRegenDelay());
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0 && !isInvicible)
        {
            currentHealth -= damage;

            AudiosHandler.instance.TakeDamageAudioPlay();
            DisplayTakeDamage();
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

    private void DisplayTakeDamage()
    {
        sprite.color = Color.red;
        StartCoroutine(SpriteRecolorDelay());
        
        IEnumerator SpriteRecolorDelay()
        {
            yield return new WaitForSeconds(.1f);
            sprite.color = defaultColor;
        }
    }

    public void SetInvicible(bool state)
    {
        isInvicible = state;
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
