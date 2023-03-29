using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    private Slider manaBar;

    void Start()
    {
        manaBar = GetComponent<Slider>();
    }

    void Update()
    {
        manaBar.value = ManaSystem.GetManaValue() / (ManaSystem.GetMaxManaValue() / manaBar.maxValue);
    }
}
