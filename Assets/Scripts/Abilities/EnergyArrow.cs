using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnergyArrow : ShootingAbility
{
    public GameObject projectile;

    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        createdProj.transform.parent = null;
    }

    private void Update()
    {
        if (Input.GetKey(keyCode))
        {
            TriggerAbility();
        }
    }

    public override void AbilityUpgrade()
    {
        Debug.Log("EnergyArrow Is Upgraded");
    }
}
