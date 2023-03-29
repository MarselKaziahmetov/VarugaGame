using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBeh : MonoBehaviour
{
    private float speed;
    private int damage;
    private float timeToDestroy;
    private int extraPentration;

    private Axe axe;

    private void Start()
    {
        axe = FindObjectOfType<Axe>().GetComponent<Axe>();

        extraPentration = axe.extraPentration;
        speed = axe.speed;
        damage = axe.damage;
        timeToDestroy = axe.timeToDestroy;
    }

    void Update()
    {
        Vector3 newPosition = transform.position + transform.right * speed * Time.deltaTime;
        transform.position = newPosition;

        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            if (extraPentration == 0)
            {
                Destroy(gameObject);
            }
            extraPentration--;
        }
    }
}
