using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesHandler : MonoBehaviour
{
    [SerializeField] private EnergyArrow energyArrow;
    [SerializeField] private Axe Axe;
    [SerializeField] private Dash dash;

    public void UnlockAbility(MonoBehaviour ability)
    {
        if (!ability.enabled)
        {
            ability.enabled = true;
        }
    }

    public void LockAbility(MonoBehaviour ability)
    {
        if (ability.enabled)
        {
            ability.enabled = false;
        }
    }

    public bool IsAbilityUnlocked(MonoBehaviour ability)
    {
        return ability.gameObject.activeSelf;
    }

}
