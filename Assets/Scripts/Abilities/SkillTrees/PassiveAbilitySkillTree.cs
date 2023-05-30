using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilitySkillTree : AbilitiesSkillTree
{
    private PlayerHealthSystem playerHealth;
    private PlayerManaSystem playerMana;
    private PlayerMovement playerMovement;
    private PlayerLevel playerLevel;

    void Start()
    {
        InitializeText();
        playerLevel = PlayerLevel.instance;
        playerMana = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void IncreseExperienceModifier()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerLevel.ExpirienceModifier += reinforcement;
        }
    }

    public void IncreseMovementSpeed()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerMovement.IncreaseMovementSpeed(reinforcement);
        }
    }

    public void IncreseMaxHealth()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerHealth.IncreaseMaxHealth(Convert.ToInt32(reinforcement));
        }
    }

    public void IncreseHealthRegeneration()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerHealth.EnableHealthRegen();
            playerHealth.IncreaseHealthRegenValue(Convert.ToInt32(reinforcement));
        }
    }

    public void IncreseMaxMana()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerMana.IncreaseMaxMana(Convert.ToInt32(reinforcement));
        }
    }

    public void IncreseManaRegeneration()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            playerMana.EnableManaRegen();
            playerMana.IncreaseManaRegenValue(Convert.ToInt32(reinforcement));
        }
    }
}
