using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : SpawnerAbility
{
    public override void AbilityUse()
    {
        AudiosHandler.instance.AxeAudioPlay();
        GameObject createdProj = Instantiate(projectile, transform);
        createdProj.transform.parent = null;
        createdProj.transform.localScale *= sizeModifier;
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
