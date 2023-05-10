using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBeh : MonoBehaviour
{
    [SerializeField] private ParticleSystem aura;

    private float timeToDestroy;
    private float size;

    private Shield shield;

    private void Start()
    {
        shield = GameObject.FindWithTag("Shield").GetComponent<Shield>();

        timeToDestroy = shield.timeToDestroy;
        size = shield.sizeModifier;

        var mainModule = aura.main;
        mainModule.startSize = size;
        mainModule.duration = timeToDestroy - .75f;

        aura.Play();

        Invoke(nameof(DestroyProjectile), timeToDestroy);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
