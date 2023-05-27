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
    private List<EnemyHealthSystem> enemiesInRange = new List<EnemyHealthSystem>();

    private void Start()
    {
        overloadZone = GameObject.FindWithTag("OverloadZone").GetComponent<OverloadZone>();

        damage = overloadZone.damage;
        timeToDestroy = overloadZone.timeToDestroy;
        damageFrequency = overloadZone.damageFrequency;

        timer = 0;

        var mainModule = aura.main;
        mainModule.duration = timeToDestroy - .75f;

        mainModule = lightnings.main;
        mainModule.duration = timeToDestroy - .75f;

        aura.Play();
        lightnings.Play();
        AudiosHandler.instance.OverloadZoneAudioPlay();

        Invoke(nameof(DestroyProjectile), timeToDestroy);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            DealDamageToEnemiesInRange();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealthSystem hp = collision.GetComponent<EnemyHealthSystem>();
            
            if (!enemiesInRange.Contains(hp))
            {
                enemiesInRange.Add(hp);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealthSystem hp = collision.GetComponent<EnemyHealthSystem>();

            if (enemiesInRange.Contains(hp))
            {
                enemiesInRange.Remove(hp);
            }
        }
    }

    private void DestroyProjectile()
    {
        AudiosHandler.instance.OverloadZoneAudioStop();
        Destroy(gameObject);
    }

    private void DealDamageToEnemiesInRange()
    {
        foreach (EnemyHealthSystem hp in enemiesInRange)
        {
            hp.TakeDamage(damage);
        }
        timer = damageFrequency;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overloadZone.sizeModifier);
    }
}
