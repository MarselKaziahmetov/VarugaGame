using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerAbilitySkillTree : AbilitiesSkillTree
{
    public enum AbilityType
    {
        EnergyArrow,
        Axe,
        OverloadZone,
        Shield
    }

    public AbilityType abilityType;
    [HideInInspector] public SpawnerAbility ability;

    void Start()
    {
        switch (abilityType)
        {
            case AbilityType.EnergyArrow:
                ability = GameObject.FindWithTag("EnergyArrow").GetComponent<EnergyArrow>();
                break;
            case AbilityType.Axe:
                ability = GameObject.FindWithTag("Axe").GetComponent<Axe>();
                break;
            case AbilityType.OverloadZone:
                ability = GameObject.FindWithTag("OverloadZone").GetComponent<OverloadZone>();
                break;
            case AbilityType.Shield:
                ability = GameObject.FindWithTag("Shield").GetComponent<Shield>();
                break;
            default:
                break;
        }

        InitializeText();
    }
    public void LevelUpMultiplier()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseProjectileMultiplier(Convert.ToInt32(reinforcement));
        }
    }

    public void LevelUpSize()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreseSize(reinforcement);
        }
    }

    public void LevelUpCooldownIme()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.DecreaseCooldownTime(reinforcement);
        }
    }

    public void LevelUpManaCost()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.DecreaseManaCost(Convert.ToInt32(reinforcement));
        }
    }

    public void LevelUpSpeed()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseSpeed(reinforcement);
        }
    }

    public void LevelUpDamage()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseDamage(reinforcement);
        }
    }

    public void LevelUpExtraPentration()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseExtraPentration(Convert.ToInt32(reinforcement));
        }
    }

    public void LevelUpDamageFrequency()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.DecreseFrequency(reinforcement);
        }
    }

    public void LevelUpDuration()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreseDuration(reinforcement);
        }
    }
}
