using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnergyArrow : ShootingAbility
{
    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        createdProj.transform.parent = null;
        createdProj.transform.localScale = createdProj.transform.localScale * sizeModifier;
    }

    private void Update()
    {
        if (Input.GetKey(keyCode))
        {
            TriggerAbility();
        }
    }
}
