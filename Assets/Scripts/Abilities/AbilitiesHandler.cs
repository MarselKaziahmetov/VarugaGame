using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesHandler : MonoBehaviour
{
    [SerializeField] private EnergyArrow energyArrow;
    [SerializeField] private Axe Axe;
    [SerializeField] private Dash dash;
    [SerializeField] private OverloadZone OverloadZone;
    [SerializeField] private Shield shield;

    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (player)
        {
            transform.position = player.transform.position;
        }
    }

    public void LockAllAbilities()
    {
        LockAbility(energyArrow);
        LockAbility(Axe);
        LockAbility(dash);
        LockAbility(OverloadZone);
        LockAbility(shield);
    }

    public void UnlockAllAbilities()
    {
        UnlockAbility(energyArrow);
        UnlockAbility(Axe);
        UnlockAbility(dash);
        UnlockAbility(OverloadZone);
        UnlockAbility(shield);
    }

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
