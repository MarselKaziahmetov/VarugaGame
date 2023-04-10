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
    public int damage;
    public int extraPentration;
    public float sizeModifier;
    public float timeToDestroy;

    [HideInInspector] public bool canUse = true;

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
        if (cooldownTime - value < 0)
        {
            cooldownTime = 0;
        }
        else
        {
            cooldownTime -= value;
        }
    }

    public void IncreaseCooldownIme(float value)
    {
        cooldownTime += value;
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

    public void IncreaseManaCost(int value)
    {
        manaCost += value;   
    }

    public void DecreaseSpeed(float value)
    {
        if (speed - value < 0)
        {
            speed = 0;
        }
        else
        {
            speed -= value;
        }
    }

    public void IncreaseSpeed(float value)
    {
        speed += speed / 100 * value;
    }

    public void DecreaseDamage(int value)
    {
        if (damage - value < 0)
        {
            damage = 0;
        }
        else
        {
            damage -= value;
        }
    }

    public void IncreaseDamage(int value)
    {
        damage += value;
    }

    public void DecreaseExtraPenetration(int value)
    {
        if (extraPentration - value < 0)
        {
            extraPentration = 0;
        }
        else
        {
            extraPentration -= value;
        }
    }

    public void IncreaseExtraPentration(int value)
    {
        extraPentration += value;
    }

}
