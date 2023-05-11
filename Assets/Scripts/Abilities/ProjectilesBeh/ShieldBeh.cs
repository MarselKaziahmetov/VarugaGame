using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBeh : MonoBehaviour
{
    [SerializeField] private ParticleSystem aura;

    private float timeToDestroy;
    private float size;

    private Shield shield;
    private PlayerHealthSystem hp;

    private void Start()
    {
        shield = GameObject.FindWithTag("Shield").GetComponent<Shield>();
        hp = GameObject.FindWithTag("Player").GetComponent<PlayerHealthSystem>();

        hp.SetInvicible(true);
        timeToDestroy = shield.timeToDestroy;
        size = shield.sizeModifier;

        var mainModule = aura.main;
        mainModule.startSize = size;
        mainModule.duration = timeToDestroy - .75f;

        aura.Play();
        AudiosHandler.instance.ShieldAudioPlay();

        Invoke(nameof(DestroyProjectile), timeToDestroy);
    }

    private void Update()
    {
        hp.SetInvicible(true);
    }

    private void DestroyProjectile()
    {
        hp.SetInvicible(false);
        AudiosHandler.instance.ShieldAudioStop();
        Destroy(gameObject);
    }
}
