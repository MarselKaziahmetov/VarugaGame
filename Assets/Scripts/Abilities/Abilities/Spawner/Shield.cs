using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SpawnerAbility
{
    public override void AbilityUse()
    {
        GameObject createdProj = Instantiate(projectile, transform);
        //createdProj.transform.parent = null;
        createdProj.transform.localScale *= sizeModifier;
        manaSystem.UseMana(manaCost);
    }

    private void Update()
    {
        if (Input.GetKey(keyCode))
        {
            TriggerAbility();
        }
    }
}
