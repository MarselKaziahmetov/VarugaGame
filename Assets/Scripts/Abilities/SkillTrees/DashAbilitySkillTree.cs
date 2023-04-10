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
    private DashAbility ability;

    void Start()
    {
        switch (abilityType)
        {
            case AbilityType.Dash:
                ability = GameObject.FindWithTag("Dash").GetComponent<DashAbility>();
                break;
            default:
                break;
        }

        InitializeText();
    }
}
