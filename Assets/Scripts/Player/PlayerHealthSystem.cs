using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float deathTimeDuration;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Animator deathPanelAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Timer timer;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AbilitiesHandler abilitiesHandler;

    private int currentHealth;
    private int healthRegenValue;
    private bool healthRegenIsEnabled;
    private bool isDead;
    private float time;
    private bool isInvicible;
    private Color defaultColor;
    private Collider2D collider2d;
    private PlayerMovement playerMovement;

    private void Start()
    {
        healthRegenValue = 0;
        time = 1;
        isInvicible = false;
        isDead = false;

        playerMovement = GetComponent<PlayerMovement>();
        collider2d = GetComponent<Collider2D>();

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
        playerMovement.enabled = false;
        collider2d.enabled = false;
        abilitiesHandler.LockAllAbilities();

        Invoke(nameof(ActivateDeathPanel), deathTimeDuration);   
        Destroy(gameObject, deathTimeDuration);

        if (!isDead)
        {
            playerAnim.SetBool("isDead", true);
            isDead = true;
        }
        timer.timerIsActivated = false;
    }

    private void ActivateDeathPanel()
    {
        deathPanel.SetActive(true);
        deathPanelAnim.SetBool("IsLightning", true);
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
