using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilitySkillTree : AbilitiesSkillTree
{
    public enum AbilityType
    {
        EnergyArrow,
        Axe,
        Dash
    }

    public AbilityType abilityType;
    [HideInInspector] public PassiveAbility ability;

    void Start()
    {
        /*switch (abilityType)
        {
            case AbilityType.EnergyArrow:
                ability = GameObject.FindWithTag("EnergyArrow").GetComponent<EnergyArrow>();
                break;
            case AbilityType.Axe:
                ability = GameObject.FindWithTag("Axe").GetComponent<Axe>();
                break;
            case AbilityType.Dash:
                ability = GameObject.FindWithTag("Axe").GetComponent<Axe>();
                break;
            default:
                break;
        }*/

        InitializeText();
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
            ability.DecreaseManaCost(reinforcement);
        }
    }
}
