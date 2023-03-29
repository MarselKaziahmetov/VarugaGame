using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject itemsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject skillsPanel;

    private GameStateSwitcher gameStateSwitcher;

    private void Start()
    {
        gameStateSwitcher = GameStateSwitcher.instance;
        pausePanel.SetActive(false);
        itemsPanel.SetActive(false);
        skillsPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            switch (skillsPanel.activeInHierarchy)
            {
                case true:
                    skillsPanel.SetActive(false);
                    gameStateSwitcher.Resume();
                    return;

                case false:
                    skillsPanel.SetActive(true);
                    gameStateSwitcher.Pause();
                    return;
            }
        }
    }

    public void OnPauseButton()
    {
        pausePanel.SetActive(true);
        gameStateSwitcher.Pause();
    }

    public void OnResumeButton()
    {
        pausePanel.SetActive(false);
        gameStateSwitcher.Resume();
    }

    public void OnItemsButton()
    {
        pausePanel.SetActive(false);
        itemsPanel.SetActive(true);
    }
    public void OnItemsBackButton()
    {
        itemsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void OnSettingsButton()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnSettingsBackButton()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void OnExitMenuButton()
    {
        gameStateSwitcher.Resume();
        SceneManager.LoadScene("Menu");
    }

    public void OnExitGameButton()
    {
        Application.Quit();
    }
}
