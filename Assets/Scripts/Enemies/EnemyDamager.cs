using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageTicks;

    private PlayerHealthSystem hp;
    private Coroutine damageDeal;

    void Start()
    {
        hp = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damageDeal = StartCoroutine(DamageDeal());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(damageDeal);
        }
    }

    IEnumerator DamageDeal()
    {
        while (true)
        {
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
            yield return new WaitForSeconds(damageTicks);
        }
    }
}
