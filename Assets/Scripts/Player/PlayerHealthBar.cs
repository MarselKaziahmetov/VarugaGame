using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider healthBar;
    private PlayerHealthSystem playerHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    void Update()
    {
        healthBar.value = playerHealth.GetHealthValue() / (playerHealth.GetMaxHealthValue() / healthBar.maxValue);
    }
}
