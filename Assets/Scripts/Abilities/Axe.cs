using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : ShootingAbility
{
    public GameObject projectile;

    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        createdProj.transform.parent = null;
        ManaSystem.UseMana(manaCost);
    }

    private void Update()
    {
        if (Input.GetKey(keyCode) && ManaSystem.GetManaValue() >= manaCost)
        {
            TriggerAbility();
        }   
    }

    public override void AbilityUpgrade()
    {

    }
}
