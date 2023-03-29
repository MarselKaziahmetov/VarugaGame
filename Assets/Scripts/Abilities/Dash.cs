using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ActiveAbilities
{
    [SerializeField] private float dashDistance = 5f; 
    public float dashDuration = 0.5f; 
    [SerializeField] private Transform player;
    [SerializeField] private TrailRenderer trail;

    private float currentDashTime = 0f;
    private float currentCooldownTime = 0f;

    private Vector2 dashDirection;

    private void Start()
    {
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
        if (Input.GetKey(keyCode) && canUse && currentCooldownTime <= 0f && ManaSystem.GetManaValue() >= manaCost && new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) != Vector2.zero)
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

    public override void AbilityUpgrade()
    {

    }

    void StartDash()
    {
        dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        currentDashTime = 0f;
        canUse = false;

        trail.emitting = true;
        ManaSystem.UseMana(manaCost);
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
