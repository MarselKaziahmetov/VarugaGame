using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingAbilityCooldownIcon : MonoBehaviour
{
    [SerializeField] private Abilitities abilitities;

    private Image icon;

    private Axe axe;
    private EnergyArrow energyArrow;

    private float cooldown;
    private KeyCode key;
    private bool canUse = true;

    enum Abilitities
    {
        axe,
        energyArrow
    }

    void Start()
    {
        axe = GameObject.FindWithTag("Axe").GetComponent<Axe>();
        energyArrow = GameObject.FindWithTag("EnergyArrow").GetComponent<EnergyArrow>();
        icon = GetComponent<Image>();

        icon.fillAmount = 0;

        switch (abilitities)
        {
            case Abilitities.axe:
                cooldown = axe.cooldownTime;
                key = axe.keyCode;
                break;
            case Abilitities.energyArrow:
                cooldown = energyArrow.cooldownTime;
                key = energyArrow.keyCode;
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
            canUse = false;
            icon.fillAmount = 1;
        }

        if (!canUse)
        {
            icon.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (icon.fillAmount <= 0)
            {
                icon.fillAmount = 0;
                canUse = true;
            }
        }
    }
}
