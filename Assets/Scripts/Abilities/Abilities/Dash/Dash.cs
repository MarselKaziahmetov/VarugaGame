using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : DashAbility
{
    private float currentDashTime = 0f;
    private float currentCooldownTime = 0f;

    private Vector2 dashDirection;

    private void Start()
    {
        manaSystem = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();

        currentCooldownTime = 0f;
        canUse = true;
        trail.emitting = false;
    }
    void Update()
    {
        TriggerAbility();
    }

    public override void AbilityUse()
    {
        if (Input.GetKey(keyCode) && canUse && currentCooldownTime <= 0f && manaSystem.GetManaValue() >= manaCost && new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) != Vector2.zero)
        {
            StartDash();
        }

        if (!canUse)
        {
            Dashing();
        }

        if (currentCooldownTime > 0f)
        {
            currentCooldownTime -= Time.deltaTime;
        }
    }

    void StartDash()
    {
        dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        currentDashTime = 0f;
        canUse = false;

        trail.emitting = true;
        manaSystem.UseMana(manaCost);
    }

    void Dashing()
    {
        if (currentDashTime >= dashDuration)
        {
            canUse = true;
            currentCooldownTime = cooldownTime;
            trail.emitting = false;
            return;
        }

        currentDashTime += Time.deltaTime;

        if (dashDirection.y == 0 || dashDirection.x == 0)
        {
            player.position += (Vector3)dashDirection * dashDistance * Time.deltaTime / dashDuration;
        }
        else
        {
            player.position += (Vector3)dashDirection * 0.75f * dashDistance * Time.deltaTime / dashDuration;
        }
    }
}
