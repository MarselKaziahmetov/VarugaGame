using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DashAbility : Ability
{
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    public Transform player;
    public TrailRenderer trail;

    public override void TriggerAbility()
    {
        AbilityUse();
    }

    public override void AbilityUse() { }

    public void DecreaseDashDuration(float value)
    {
        AddInPercent(ref dashDuration, -value);
        if (dashDuration < 0)
        {
            dashDuration = 0;
        }
    }
    public void IncreaseDashDistance(float value)
    {
        AddInPercent(ref dashDistance, value);
    }
}
