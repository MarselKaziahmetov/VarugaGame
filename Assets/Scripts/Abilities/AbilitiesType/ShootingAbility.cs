using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ShootingAbility : MonoBehaviour
{
    //public class MyFloatEvent : UnityEvent<float> { }
    //public MyFloatEvent OnAbilityUse = new MyFloatEvent();
    [Header("Ability Info and Stats")]
    public string title;
    public KeyCode keyCode;
    public float cooldownTime;
    public int manaCost;    
    public float speed;
    public float damage;
    public int extraPentration;
    public float timeToDestroy;
    public float sizeModifier;
    public List<GameObject> projectilesMultiplier;

    [HideInInspector] public bool canUse = true;
    [HideInInspector] public GameObject projectile;
    [HideInInspector] public PlayerManaSystem manaSystem;
    [HideInInspector] public int quantityMultiplier;

    private void Start()
    {
        IncreaseProjectileMultiplier(0);
        sizeModifier = 1;
        quantityMultiplier = 0;
    }

    public void TriggerAbility()
    {
        if (canUse)
        {
            //OnAbilityUse.Invoke(cooldownTime);
            AbilityUse();
            StartCooldown();
        }
    }
    public abstract void AbilityUse();

    void StartCooldown()
    {
        StartCoroutine(Cooldown());
        IEnumerator Cooldown()
        {
            canUse = false;
            yield return new WaitForSeconds(cooldownTime);
            canUse = true;
        }
    }

    public void DecreaseCooldownIme(float value)
    {
        AddInPercent(ref cooldownTime, -value);
        if (cooldownTime < 0)
        {
            cooldownTime = 0;
        }
    }

    public void DecreaseManaCost(int value)
    {
        if (manaCost - value < 0)
        {
            manaCost = 0;
        }
        else
        {
            manaCost -= value;
        }
    }

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

    private void AddInPercent(ref float value, float addValue)
    {
        value += value / 100 * addValue;
    }
}
