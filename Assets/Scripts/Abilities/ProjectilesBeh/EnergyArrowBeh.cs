using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyArrowBeh : MonoBehaviour
{
    private float speed;
    private float damage;
    private float timeToDestroy;
    private int extraPentration;
    //[SerializeField] private ParticleSystem arrowPS;

    private EnergyArrow energyArrow;

    private void Start()
    {
        energyArrow = FindObjectOfType<EnergyArrow>().GetComponent<EnergyArrow>();
        speed = energyArrow.speed;
        damage = energyArrow.damage;
        timeToDestroy = energyArrow.timeToDestroy;
        extraPentration = energyArrow.extraPentration;
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
            //arrowPS.transform.parent = null;
            //arrowPS.Play();

            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            if (extraPentration == 0)
            {
                Destroy(gameObject);
            }
            extraPentration--;
        }
    }
}
