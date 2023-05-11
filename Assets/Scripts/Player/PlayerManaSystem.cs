using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaSystem : MonoBehaviour
{
    [SerializeField] private int maxMana;

    private int currentMana;
    private int manaRegenValue;
    private bool manaRegenIsEnabled;
    private float time;

    private void Start()
    {
        manaRegenValue = 0;
        time = 1;

        currentMana = maxMana;
        manaRegenIsEnabled = false;

        StartCoroutine(manaRegenDelay());
    }

    public void UseMana(int manaValue)
    {
        if (currentMana - manaValue >= 0)
        {
            currentMana -= manaValue;
        }
        else
        {
            currentMana = 0;
        }
    }

    public void IncreaseCurrentMana(int manaValue)
    {
        if (currentMana + manaValue <= maxMana)
        {
            currentMana += manaValue;
        }
        else
        {
            currentMana = maxMana;
        }
    }

    private IEnumerator manaRegenDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            ManaRegen();
        }
    }

    public void ManaRegen()
    {
        if (manaRegenIsEnabled)
        { 
            IncreaseCurrentMana(manaRegenValue);
        }
    }

    public void IncreaseManaRegenValue(int value) 
    {
        manaRegenValue += value;
    }

    public void EnableManaRegen()
    {
        manaRegenIsEnabled = true;
    }

    public void IncreaseMaxMana(int manaValue)
    {
        maxMana += manaValue;
        IncreaseCurrentMana(manaValue);
    }

    public int GetManaValue()
    {
        return currentMana;
    }
    public int GetMaxManaValue()
    {
        return maxMana;
    }

}
