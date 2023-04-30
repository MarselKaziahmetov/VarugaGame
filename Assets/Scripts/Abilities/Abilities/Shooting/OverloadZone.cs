using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadZone : ShootingAbility
{
    public float frequency;

    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        //createdProj.transform.parent = null;
        createdProj.transform.localScale *= sizeModifier;
    }

    private void Update()
    {
        if (Input.GetKey(keyCode))
        {
            TriggerAbility();
        }
    }

    public void IncreseFrequency(float value)
    {
        AddInPercent(ref frequency, value);
    }
}
