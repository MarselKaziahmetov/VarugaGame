using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ContinuedAbility : Ability
{
    public float duration;

    [Header("For Dash")]
    public float dashDistance;

    [HideInInspector] public PlayerManaSystem manaSystem;

    public override void TriggerAbility()
    {
        AbilityUse();
    }

    public override void AbilityUse() { }

    public void DecreaseDashDuration(float value)
    {
        AddInPercent(ref duration, -value);
        if (duration < 0)
        {
            duration = 0;
        }
    }
    public void IncreaseDashDistance(float value)
    {
        AddInPercent(ref dashDistance, value);
    }
}
