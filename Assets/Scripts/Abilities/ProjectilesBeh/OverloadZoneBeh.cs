using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadZoneBeh : MonoBehaviour
{
    [SerializeField] private ParticleSystem aura;
    [SerializeField] private ParticleSystem lightnings;

    private float damage;
    private float timeToDestroy;
    private float damageFrequency;

    private OverloadZone overloadZone;
    private float timer;
    private bool timerIsActivated;

    private void Start()
    {
        overloadZone = GameObject.FindWithTag("OverloadZone").GetComponent<OverloadZone>();

        damage = overloadZone.damage;
        timeToDestroy = overloadZone.timeToDestroy;
        damageFrequency = overloadZone.damageFrequency;

        timer = damageFrequency;

        var mainModule = aura.main;
        mainModule.duration = timeToDestroy - .75f;

        mainModule = lightnings.main;
        mainModule.duration = timeToDestroy - .75f;

        aura.Play();
        lightnings.Play();

        Invoke(nameof(DestroyProjectile), timeToDestroy);
    }

    private void Update()
    {
        if (timerIsActivated && timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timerIsActivated = false;
            timer = damageFrequency;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!timerIsActivated)
            {
                collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
                timerIsActivated = true;
            }
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
