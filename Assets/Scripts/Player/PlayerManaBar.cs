using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    private Slider manaBar;
    private PlayerManaSystem manaSystem;

    void Start() 
    {
        manaSystem = GameObject.FindWithTag("Player").GetComponent<PlayerManaSystem>();
        manaBar = GetComponent<Slider>();
    }

    void Update()
    {
        manaBar.value = manaSystem.GetManaValue() / (manaSystem.GetMaxManaValue() / manaBar.maxValue);
    }
}
