using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem enemyHealth;
    private Slider healthBar;

    void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBar.value = enemyHealth.GetHealthValue() / (enemyHealth.GetMaxHealthValue() / healthBar.maxValue);
    }
}
