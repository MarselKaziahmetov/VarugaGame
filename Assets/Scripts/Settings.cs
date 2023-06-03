using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [System.Serializable]
    public class ResItems
    {
        public int width;
        public int height;
    }

    public enum GameState
    {
        onMenu,
        onLevel
    }

    [Header ("Links to UI elemetns")]
    [SerializeField] private TMP_Dropdown screenResDropDown;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle volumeToggle;

    [Header("Settings parametrs")]
    public List<ResItems> resItems;
    public GameState gameState;

    [Header("Menu Settings")]
    public AudioSource menuAudio;

    private const string VolumeKey = "Volume";
    private const string ResolutionIndexKey = "ResolutionIndex";
    private const string FullscreenKey = "Fullscreen";

    void Start()
    {
        // ��������� ����������� ���������
        LoadSettings();

        // ��������� ���������
        ApplySettings();
    }

    public void SetVolume()
    {
        switch (gameState)
        {
            case GameState.onMenu:
                if (volumeToggle.isOn)
                {
                    menuAudio.mute = true;
                }
                else
                {
                    menuAudio.mute = false;
                }
                break;
            case GameState.onLevel:
                if (volumeToggle.isOn)
                {
                    AudiosHandler.instance.MuteVolume();
                }
                else
                {
                    AudiosHandler.instance.UnMuteVolmue();
                }
                break;
            default:
                break;
        }

        // ��������� ���������
        SaveSettings();
    }

    public void SetResolution()
    {
        // ������������� ���������� ������ �� �������
        Screen.SetResolution(resItems[screenResDropDown.value].width, resItems[screenResDropDown.value].height, fullscreenToggle.isOn);

        // ��������� ���������
        SaveSettings();
    }

    public void SetFullscreen()
    {
        // ������������� ������������� �����
        Screen.fullScreen = fullscreenToggle.isOn;

        // ��������� ���������
        SaveSettings();
    }

    private void LoadSettings()
    {
        // ��������� ����������� ��������� ��� ���������� �������� �� ���������
        volumeToggle.isOn = IntToBool(PlayerPrefs.GetInt(VolumeKey));
        screenResDropDown.value = PlayerPrefs.GetInt(ResolutionIndexKey);
        fullscreenToggle.isOn = IntToBool(PlayerPrefs.GetInt(FullscreenKey));
    }

    private void SaveSettings()
    {
        // ��������� ������� ���������
        PlayerPrefs.SetInt(VolumeKey, BoolToInt(volumeToggle.isOn));
        PlayerPrefs.SetInt(ResolutionIndexKey, screenResDropDown.value);
        PlayerPrefs.SetInt(FullscreenKey, BoolToInt(fullscreenToggle.isOn));
        PlayerPrefs.Save();
    }

    private void ApplySettings()
    {
        // ��������� ���������
        SetFullscreen();
        SetResolution();
        SetVolume();
    }

    int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool IntToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
