using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public int maxManaValue;

    private static int maxMana;
    private static int currentMana;

    private void Start()
    {
        maxMana = maxManaValue;
        currentMana = maxMana;
    }

    public static void UseMana(int manaValue)
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

    public static void IncreaseCurrentMana(int manaValue)
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

    public static void IncreaseMaxMana(int manaValue)
    {
        maxMana = manaValue;
    }

    public static int GetManaValue()
    {
        return currentMana;
    }
    public static int GetMaxManaValue()
    {
        return maxMana;
    }

}
