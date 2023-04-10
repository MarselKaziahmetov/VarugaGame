using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingAbilitySkillTree : AbilitiesSkillTree
{
    public enum AbilityType
    {
        EnergyArrow,
        Axe
    }

    public AbilityType abilityType;
    private ShootingAbility ability;

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
            default:
                break;
        }

        InitializeText();
    }

    public void LevelUpCooldownIme()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseCooldownIme(reinforcement);
        }
    }

    public void LevelUpManaCost()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.DecreaseManaCost(reinforcement); 
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
            ability.IncreaseExtraPentration(reinforcement); 
        }
    }
}
