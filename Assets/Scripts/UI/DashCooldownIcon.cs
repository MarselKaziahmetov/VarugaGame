using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownIcon : MonoBehaviour
{
    private Image icon;

    private Dash dash;

    private float cooldown;
    private KeyCode key;
    private bool canUse = true;

    void Start()
    {
        dash = GameObject.FindWithTag("Dash").GetComponent<Dash>();
        icon = GetComponent<Image>();

        icon.fillAmount = 0;

        cooldown = dash.cooldownTime;
        key = dash.keyCode;
    }

    void Update()
    {
        IconReloading();
    }

    private void IconReloading()
    {
        if (Input.GetKey(key) && canUse && !dash.canUse)
        {
            canUse = false;
            icon.fillAmount = 1;
        }

        if (!canUse)
        {
            icon.fillAmount -= 1 / (cooldown + dash.dashDuration) * Time.deltaTime;

            if (icon.fillAmount <= 0)
            {
                icon.fillAmount = 0;
                canUse = true;
            }
        }
    }
}
