using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearenceEffect : MonoBehaviour
{
    [SerializeField] private GameObject particleObject;
    [SerializeField] private float delay;

    private ParticleSystem particle;
    
    void Start()
    {
        particle = particleObject.GetComponent<ParticleSystem>();
        Invoke(nameof(ParticlesActivation), delay);       
    }

    private void ParticlesActivation()
    {
        particleObject.SetActive(true);
        particle.Play();
    }
}
