using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ShootingAbility : Ability
{ 
    public float speed;
    public float damage;
    public int extraPentration;
    public float timeToDestroy;
    public float sizeModifier; 
    public float damageFrequency;
    public List<GameObject> projectilesMultiplier;

    [HideInInspector] public PlayerManaSystem manaSystem;
    [HideInInspector] public GameObject projectile;
    [HideInInspector] public int quantityMultiplier;

    private void Start()
    {
        manaSystem = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();

        IncreaseProjectileMultiplier(0);
        sizeModifier = 1;
        quantityMultiplier = 0;
    }

    public override void TriggerAbility()
    {
        if (canUse)
        {
            AbilityUse();
            StartCooldown();
        }
    }

    public override void AbilityUse() { }

    public void IncreaseProjectileMultiplier(int value)
    {
        quantityMultiplier += value;
        projectile = projectilesMultiplier[quantityMultiplier];
    }

    public void IncreseSize(float value)
    {
        AddInPercent(ref sizeModifier, value);
    }

    public void IncreaseSpeed(float value)
    {
        AddInPercent(ref speed, value);
    }

    public void IncreaseDamage(float value)
    {
        AddInPercent(ref damage, value);
    }

    public void IncreaseExtraPentration(int value)
    {
        extraPentration += value;
    }

    public void DecreseFrequency(float value)
    {
        AddInPercent(ref damageFrequency, -value);
    }
    public void IncreseDuration(float value)
    {
        AddInPercent(ref timeToDestroy, value);
    }
}
