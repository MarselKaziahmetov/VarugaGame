using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosHandler : MonoBehaviour
{
    public static AudiosHandler instance;

    [SerializeField] private AudioSource levelBackgroundAudio;
    [SerializeField] private AudioSource skillTreeAudio;
    [SerializeField] private AudioSource takeDamageAudio;
    [SerializeField] private AudioSource energyArrowAudio;
    [SerializeField] private AudioSource axeAudio;
    [SerializeField] private AudioSource dashAudio;
    [SerializeField] private AudioSource overloadZoneAudio;
    [SerializeField] private AudioSource shieldAudio;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        takeDamageAudio.Stop();
        skillTreeAudio.Stop();

        levelBackgroundAudio.Play();
    }

    public void MuteVolume()
    {


        levelBackgroundAudio.mute = true;
        skillTreeAudio.mute = true;
        takeDamageAudio.mute = true;
        energyArrowAudio.mute = true;
        axeAudio.mute = true;
        dashAudio.mute = true;
        overloadZoneAudio.mute = true;
        shieldAudio.mute = true;
    }

    public void UnMuteVolmue()
    {
        levelBackgroundAudio.mute = false;
        skillTreeAudio.mute = false;
        takeDamageAudio.mute = false;
        energyArrowAudio.mute = false;
        axeAudio.mute = false;
        dashAudio.mute = false;
        overloadZoneAudio.mute = false;
        shieldAudio.mute = false;
    }

    public void LevelAudioPlay()
    {
        levelBackgroundAudio.Play();
    }

    public void LevelAudioPause()
    {
        levelBackgroundAudio.Pause();
    }

    public void SkillTreeAudioPlay()
    {
        skillTreeAudio.Play();
    }

    public void SkillTreeAudioPause()
    {
        skillTreeAudio.Pause();
    }

    public void TakeDamageAudioPlay()
    {
        takeDamageAudio.Play();
    }

    public void TakeDamageAudioPause()
    {
        takeDamageAudio.Pause();
    }

    public void EnergyArrowAudioPlay()
    {
        energyArrowAudio.Play();
    }

    public void EnergyArrowAudioStop()
    {
        energyArrowAudio.Stop();
    }

    public void AxeAudioPlay()
    {
        axeAudio.Play();
    }

    public void AxeAudioStop()
    {
        axeAudio.Stop();
    }

    public void DashAudioPlay()
    {
        dashAudio.Play();
    }

    public void DashAudioStop()
    {
        dashAudio.Stop();
    }

    public void OverloadZoneAudioPlay()
    {
        overloadZoneAudio.Play();
    }

    public void OverloadZoneAudioStop()
    {
        overloadZoneAudio.Stop();
    }
    public void ShieldAudioPlay()
    {
        shieldAudio.Play();
    }

    public void ShieldAudioStop()
    {
        shieldAudio.Stop();
    }
}
