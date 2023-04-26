using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbilitySkillTree : AbilitiesSkillTree
{
    public enum AbilityType
    {
        Dash
    }

    public AbilityType abilityType;
    [HideInInspector] public DashAbility ability;

    void Start()
    {
        switch (abilityType)
        {
            case AbilityType.Dash:
                ability = GameObject.FindWithTag("Dash").GetComponent<Dash>();
                break;
            default:
                break;
        }

        InitializeText();
    }
    public void LevelUpCooldownTime()
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
    public void LevelUpDashDuration()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.DecreaseDashDuration(reinforcement);
        }
    }

    public void LevelUpDashDistance()
    {
        if (PlayerLevel.instance.AbilityPoints >= abilityPointsCost)
        {
            ability.IncreaseDashDistance(reinforcement);
        }
    }
}
