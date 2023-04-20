using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : ShootingAbility
{
    private void Start()
    {
        manaSystem = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();
    }

    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        createdProj.transform.parent = null;
        manaSystem.UseMana(manaCost);
    }

    private void Update()
    {
        if (Input.GetKey(keyCode) && manaSystem.GetManaValue() >= manaCost)
        {
            TriggerAbility();
        }   
    }
}
