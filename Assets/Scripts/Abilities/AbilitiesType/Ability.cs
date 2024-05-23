using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [Header("General")]
    [Header("Ability Info and Stats")]
    public string title;        //название
    public KeyCode keyCode;     //код клавиши для активации
    public float cooldownTime;  //длительность перезарядки
    public int manaCost;        //количество маны, необходимое при активации

    [HideInInspector] public bool canUse = true;

    public abstract void TriggerAbility();
    public abstract void AbilityUse();

    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
        IEnumerator Cooldown()
        {
            canUse = false;
            yield return new WaitForSeconds(cooldownTime);
            canUse = true;
        }
    }

    public void DecreaseCooldownTime(float value)
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

    public void AddInPercent(ref float value, float addValue)
    {
        value += value / 100 * addValue;
    }
}
