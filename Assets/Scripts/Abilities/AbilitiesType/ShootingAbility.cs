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

    public abstract void AbilityUpgrade();
}
