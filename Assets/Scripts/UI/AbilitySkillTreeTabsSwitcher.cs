using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySkillTreeTabsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject passivePanel;
    [SerializeField] private GameObject enegyArrowPanel;
    [SerializeField] private GameObject holyAxePanel;
    [SerializeField] private GameObject dashPanel;
    [SerializeField] private GameObject overloadZonePanel;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    [SerializeField] private Image passivePanelIMG;
    [SerializeField] private Image enegyArrowPanelIMG;
    [SerializeField] private Image holyAxePanelIMG;
    [SerializeField] private Image dashPanelIMG;
    [SerializeField] private Image overloadZonePanelIMG;

    private GameObject currentPanel;
    private Image currentPanelIMG;
    
    void Start()
    {
        currentPanel = passivePanel;
        currentPanelIMG = passivePanelIMG;

        currentPanel.SetActive(true);
        enegyArrowPanel.SetActive(false);
        holyAxePanel.SetActive(false);
        dashPanel.SetActive(false);
        overloadZonePanel.SetActive(false);

        passivePanelIMG.color = inactiveColor;
        enegyArrowPanelIMG.color = inactiveColor;
        holyAxePanelIMG.color = inactiveColor;
        dashPanelIMG.color = inactiveColor;
        overloadZonePanelIMG.color = inactiveColor;

        currentPanelIMG.color = activeColor;
    }

    public void ChangeActivePanel(GameObject panel)
    {
        currentPanel.SetActive(false);

        currentPanel = panel;

        currentPanel.SetActive(true);
    }

    public void UpdateButtonsHighlight(Image image)
    {
        currentPanelIMG.color = inactiveColor;

        currentPanelIMG = image; 

        currentPanelIMG.color = activeColor;
    }
}
