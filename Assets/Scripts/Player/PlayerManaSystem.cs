using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaSystem : MonoBehaviour
{
    public int maxManaValue;

    private int maxMana;
    private int currentMana;

    private void Start()
    {
        maxMana = maxManaValue;
        currentMana = maxMana;
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

    public void IncreaseMaxMana(int manaValue)
    {
        maxMana = manaValue;
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
