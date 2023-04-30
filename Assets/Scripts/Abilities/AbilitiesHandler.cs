using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesHandler : MonoBehaviour
{
    [SerializeField] private EnergyArrow energyArrow;
    [SerializeField] private Axe Axe;
    [SerializeField] private Dash dash;
    [SerializeField] private OverloadZone OverloadZone;

    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position;
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
