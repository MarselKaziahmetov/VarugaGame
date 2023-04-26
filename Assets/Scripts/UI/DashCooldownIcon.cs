using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownIcon : MonoBehaviour
{
    [SerializeField] private Image border;
    private Image icon;

    private Dash dash;

    private bool canUse = true;

    void Start()
    {
        dash = GameObject.FindWithTag("Dash").GetComponent<Dash>();
        icon = GetComponent<Image>();

        icon.fillAmount = 0;
    }

    void Update()
    {
        IconReloading();
    }

    private void IconReloading()
    {
        if (Input.GetKey(dash.keyCode) && canUse && !dash.canUse)
        {
            canUse = false;
            icon.fillAmount = 1;
            border.enabled = false;
        }

        if (!canUse)
        {
            icon.fillAmount -= 1 / (dash.cooldownTime + dash.dashDuration) * Time.deltaTime;

            if (icon.fillAmount <= 0)
            {
                icon.fillAmount = 0;
                canUse = true;
                border.enabled = true;
            }
        }
    }
}
