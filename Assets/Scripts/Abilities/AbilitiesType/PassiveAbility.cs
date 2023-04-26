using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PassiveAbility : Ability
{
    public override void TriggerAbility()
    {
        if (canUse)
        {
            AbilityUse();
            StartCooldown();
        }
    }

    public override void AbilityUse() { }
}
