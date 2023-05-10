using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class SpawnerAbility : Ability
{
    public float damage;
    public float timeToDestroy;
    public float sizeModifier; 

    [Header("For Shot")]
    public float speed;
    public int extraPentration;

    [Header("For Round")]
    public float damageFrequency;

    [Header("Projectile Examples")]
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
