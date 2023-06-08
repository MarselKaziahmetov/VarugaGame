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

    private GameTimeSwitcher gameStateSwitcher;
    private LoadingScreen loadingScreen;

    private bool inSkillTree;
    private bool inPausePanel;
    private bool inChildPausePanel;

    private void Start()
    {
        loadingScreen = GetComponent<LoadingScreen>();
        gameStateSwitcher = GameTimeSwitcher.instance;
        pausePanel.SetActive(false);
        itemsPanel.SetActive(false);
        skillsPanel.SetActive(false);

        inSkillTree = false;
        inPausePanel = false;
        inChildPausePanel = false;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!skillsPanel.activeInHierarchy && !inPausePanel)
            {
                // активирует skillTreePanel
                skillsPanel.SetActive(true);
                gameStateSwitcher.Pause();
                AudiosHandler.instance.LevelAudioPause();
                AudiosHandler.instance.SkillTreeAudioPlay();
                inSkillTree = true;
            }
            else if (skillsPanel.activeInHierarchy && !inPausePanel)
            {
                // деактивирует skillTreePanel на кнопку I
                skillsPanel.SetActive(false);
                gameStateSwitcher.Resume();
                AudiosHandler.instance.SkillTreeAudioPause();
                AudiosHandler.instance.LevelAudioPlay();
                inSkillTree = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy && !inSkillTree && !inChildPausePanel)
            {
                //активирует pausePanel
                pausePanel.SetActive(true);
                gameStateSwitcher.Pause();
                inPausePanel = true;
            }
            else if (pausePanel.activeInHierarchy && !inSkillTree && !inChildPausePanel)
            {
                //деактивирует pausePanel
                pausePanel.SetActive(false);
                gameStateSwitcher.Resume();
                inPausePanel = false;
            }
            else if (skillsPanel.activeInHierarchy && !inPausePanel)
            {
                // деактивирует skillTreePanel на кнопку ESC
                skillsPanel.SetActive(false);
                gameStateSwitcher.Resume();
                AudiosHandler.instance.SkillTreeAudioPause();
                AudiosHandler.instance.LevelAudioPlay();
                inSkillTree = false;
            }
            else if ((itemsPanel.activeInHierarchy || settingsPanel.activeInHierarchy) && !inSkillTree && inChildPausePanel)
            {
                itemsPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(true);
                inChildPausePanel = false;
            }
        }
    }

    public void OnPauseButton()
    {
        pausePanel.SetActive(true);
        gameStateSwitcher.Pause();
        inPausePanel = true;
    }

    public void OnResumeButton()
    {
        pausePanel.SetActive(false);
        gameStateSwitcher.Resume();
        inPausePanel = false;
    }

    public void OnItemsButton()
    {
        pausePanel.SetActive(false);
        itemsPanel.SetActive(true);
        inChildPausePanel = true;
    }
    public void OnItemsBackButton()
    {
        itemsPanel.SetActive(false);
        pausePanel.SetActive(true);
        inChildPausePanel = false;
    }

    public void OnSettingsButton()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        inChildPausePanel = true;
    }

    public void OnSettingsBackButton()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
        inChildPausePanel = false;
    }

    public void OnExitMenuButton()
    {
        gameStateSwitcher.Resume();
        loadingScreen.Loading("Menu");
    }

    public void OnExitGameButton()
    {
        Application.Quit();
    }

    public void OnRetryGameButton()
    {
        loadingScreen.Loading(SceneManager.GetActiveScene().name);
    }
}
