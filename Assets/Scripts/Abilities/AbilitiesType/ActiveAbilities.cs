using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActiveAbilities : MonoBehaviour
{
    [Header("Ability Info and Stats")]
    public string title;
    public KeyCode keyCode;
    public int manaCost;
    public float cooldownTime = 2f;

    [HideInInspector] public bool canUse = true;

    public void TriggerAbility()
    {
        AbilityUse();
    }

    public abstract void AbilityUse();

    public abstract void AbilityUpgrade();
}
