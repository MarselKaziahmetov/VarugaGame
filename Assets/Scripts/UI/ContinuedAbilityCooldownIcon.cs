using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuedAbilityCooldownIcon : MonoBehaviour
{
    [SerializeField] private Abilities abilities;
    [SerializeField] private Image border;

    private Image icon;

    private Axe axe;
    private EnergyArrow energyArrow;
    private OverloadZone overloadZone;
    private Shield shield;

    private float cooldown;
    private KeyCode key;
    private bool canUse = true;

    enum Abilities
    {
        axe,
        energyArrow,
        overloadZone,
        shield
    }

    void Start()
    {
        axe = GameObject.FindWithTag("Axe").GetComponent<Axe>();
        energyArrow = GameObject.FindWithTag("EnergyArrow").GetComponent<EnergyArrow>();
        overloadZone = GameObject.FindWithTag("OverloadZone").GetComponent<OverloadZone>();
        shield = GameObject.FindWithTag("Shield").GetComponent<Shield>();
        icon = GetComponent<Image>();

        icon.fillAmount = 0;

        switch (abilities)
        {
            case Abilities.axe:
                cooldown = axe.cooldownTime;
                key = axe.keyCode;
                break;
            case Abilities.energyArrow:
                cooldown = energyArrow.cooldownTime;
                key = energyArrow.keyCode;
                break;
            case Abilities.overloadZone:
                cooldown = overloadZone.cooldownTime;
                key = overloadZone.keyCode;
                break;
            case Abilities.shield:
                cooldown = shield.cooldownTime;
                key = shield.keyCode;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        IconReloading();
    }

    private void IconReloading()
    {
        if (Input.GetKey(key) && canUse)
        {
            switch (abilities)
            {
                case Abilities.axe:
                    cooldown = axe.cooldownTime;
                    key = axe.keyCode;
                    break;
                case Abilities.energyArrow:
                    cooldown = energyArrow.cooldownTime;
                    key = energyArrow.keyCode;
                    break;
                case Abilities.overloadZone:
                    cooldown = overloadZone.cooldownTime;
                    key = overloadZone.keyCode;
                    break;
                case Abilities.shield:
                    cooldown = shield.cooldownTime;
                    key = shield.keyCode;
                    break;
                default:
                    break;
            }

            canUse = false;
            icon.fillAmount = 1;
            border.enabled = false;
        }

        if (!canUse)
        {
            icon.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (icon.fillAmount <= 0)
            {
                border.enabled = true;
                icon.fillAmount = 0;
                canUse = true;
            }
        }
    }
}
