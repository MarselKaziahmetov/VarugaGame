using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBeh : MonoBehaviour
{
    private float speed;
    private float damage;
    private float timeToDestroy;
    private int extraPentration;

    private Axe axe;

    private void Start()
    {
        axe = GameObject.FindWithTag("Axe").GetComponent<Axe>();

        extraPentration = axe.extraPentration;
        speed = axe.speed;
        damage = axe.damage;
        timeToDestroy = axe.timeToDestroy;

        Invoke(nameof(DestroyProjectile), timeToDestroy);
    }

    void Update()
    {
        Vector3 newPosition = transform.position + transform.right * speed * Time.deltaTime;
        transform.position = newPosition;

        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(damage);
            if (extraPentration == 0)
            {
                DestroyProjectile();
            }
            extraPentration--;
        }
        if(collision.gameObject.tag == "ObstacleMap")
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
