using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    [SerializeField] private int addHealth;
    private PlayerHealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthSystem.IncreaseCurrentHealth(addHealth);
            Destroy(gameObject);
        }
    }
}
