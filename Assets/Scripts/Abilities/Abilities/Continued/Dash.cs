using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ContinuedAbility
{
    public Transform player;
    public TrailRenderer trail;

    private float currentDashTime = 0f;
    private float currentCooldownTime = 0f;

    private Vector2 dashDirection;
    private Collider2D collider2d;
    private PlayerHealthSystem hp;

    private void Start()
    {
        manaSystem = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();
        hp = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
        collider2d = GetComponent<Collider2D>();

        currentCooldownTime = 0f;
        canUse = true;
        trail.emitting = false;
        collider2d.enabled = false;
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
            collider2d.enabled = true;
            hp.SetInvicible(true);
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
        AudiosHandler.instance.DashAudioPlay();
    }

    void Dashing()
    {
        if (currentDashTime >= duration)
        {
            canUse = true;
            currentCooldownTime = cooldownTime;
            trail.emitting = false;
            collider2d.enabled=false;
            hp.SetInvicible(false);
            return;
        }

        currentDashTime += Time.deltaTime;

        if (dashDirection.y == 0 || dashDirection.x == 0)
        {
            player.position += (Vector3)dashDirection * dashDistance * Time.deltaTime / duration;
            hp.SetInvicible(true);
        }
        else
        {
            player.position += (Vector3)dashDirection * 0.75f * dashDistance * Time.deltaTime / duration;
            hp.SetInvicible(true);
        }
    }
}
