using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySkillTreeTabsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject enegyArrowPanel;
    [SerializeField] private GameObject holyAxePanel;
    [SerializeField] private GameObject dashPanel;

    private GameObject currentPanel;
    void Start()
    {
        currentPanel = enegyArrowPanel;

        currentPanel.SetActive(true);
        holyAxePanel.SetActive(false);
        dashPanel.SetActive(false);
    }

    public void ChangeActivePanel(GameObject panel)
    {
        currentPanel.SetActive(false);
        currentPanel = panel;
        currentPanel.SetActive(true);
    }
}
