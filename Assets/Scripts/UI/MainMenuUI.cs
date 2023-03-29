using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject upgradesPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject characterPanel;

    private GameObject currentPanel;

    private void Start()
    {
        currentPanel = mainPanel;    

        currentPanel.SetActive(true);
        settingsPanel.SetActive(false);
        levelPanel.SetActive(false);
        upgradesPanel.SetActive(false);
        aboutPanel.SetActive(false);
        characterPanel.SetActive(false);
    }

    private void PanelSwitcher(GameObject panelOn)
    {
        currentPanel.SetActive(false);
        panelOn.SetActive(true);
        currentPanel = panelOn;
    }

    public void StartButton()
    {
        PanelSwitcher(levelPanel);
    }

    public void LocTest()
    {
        SceneManager.LoadScene("TestLocation");
    }

    public void UpgradeButton()
    {
        PanelSwitcher(upgradesPanel);
    }

    public void SettingsButton()
    {
        PanelSwitcher(settingsPanel);
    }

    public void CharactersButton()
    {
        PanelSwitcher(characterPanel);
    }

    public void AboutButton()
    {
        PanelSwitcher(aboutPanel);
    }

    public void BackButton()
    {
        PanelSwitcher(mainPanel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
