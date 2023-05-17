using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetCoin();
        }
    }

    private void GetCoin()
    {
        Bank.instance.CoinsAmount += amount;
        Destroy(gameObject);
    }
}
