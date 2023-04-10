using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilitySkillTree : AbilitiesSkillTree
{
    public enum AbilityType
    {
        
    }

    public AbilityType abilityType;
    private PassiveAbility  ability;

    void Start()
    {
        /*switch (abilityType)
        {
            case AbilityType.EnergyArrow:
                ability = GameObject.FindWithTag("EnergyArrow").GetComponent<EnergyArrow>();
                break;
            default:
                break;
        }*/

        InitializeText();
    }
}
