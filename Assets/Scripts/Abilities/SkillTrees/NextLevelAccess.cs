using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelAccess : MonoBehaviour
{
    public enum TreesType
    {
        ShootngType,
        PassiveType,
        DashType
    }

    [Header("Type Of Ability Tree")]
    [SerializeField] private TreesType treesType;

    [Header("Sources On Objects")]
    [SerializeField] private List<GameObject> buttonObject; 
    [SerializeField] private List<Image> borders;

    [Header("Colors For Button States")]
    [SerializeField] private Color lockedColor;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color completedColor;

    [Header("Colors For Border States")]
    [SerializeField] private Color unavialableColor;
    [SerializeField] private Color avialableColor;
    [SerializeField] private Color fulledColor;
    
    private List<AbilitiesSkillTree> skillTree; 
    private List<Button> buttonComponent;
    private List<Image> imageComponent;

    private int activeIndex = 0;
    private int nextIndex = 1;

    private void Start()
    {
        skillTree = new List<AbilitiesSkillTree>();
        buttonComponent = new List<Button>();
        imageComponent = new List<Image>();

        for (int i = 0; i < buttonObject.Count; i++)
        {
            switch (treesType)
            {
                case TreesType.ShootngType:
                    skillTree.Add(buttonObject[i].GetComponent<ShootingAbilitySkillTree>());
                    break;
                case TreesType.PassiveType:
                    skillTree.Add(buttonObject[i].GetComponent<PassiveAbilitySkillTree>());
                    break;
                case TreesType.DashType:
                    skillTree.Add(buttonObject[i].GetComponent<DashAbilitySkillTree>());
                    break;
                default:
                    break;
            }
            buttonComponent.Add(buttonObject[i].GetComponent<Button>());
            imageComponent.Add(buttonObject[i].GetComponent<Image>());
        }

        imageComponent[0].color = defaultColor;
        for (int i = 1; i < buttonObject.Count; i++)
        {
            buttonComponent[i].interactable = false;
            imageComponent[i].color = lockedColor;
        }

        UpdateBordersColor();
    }

    public void OpenAccessToNextLevel()
    {
        if (activeIndex == (buttonObject.Count - 1) && skillTree[activeIndex].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
        {
            buttonComponent[activeIndex].interactable = false;
            imageComponent[activeIndex].color = completedColor;

            PlayerLevel.instance.AbilityPoints -= skillTree[activeIndex].abilityPointsCost;

            UpdateBordersColor();
        }
        else if(activeIndex < (buttonObject.Count - 1) && skillTree[activeIndex].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
        {
            buttonComponent[activeIndex].interactable = false;
            imageComponent[activeIndex].color = completedColor;

            buttonComponent[nextIndex].interactable = true;
            imageComponent[nextIndex].color = defaultColor;

            PlayerLevel.instance.AbilityPoints -= skillTree[activeIndex].abilityPointsCost;

            activeIndex++;
            nextIndex++;

            UpdateBordersColor();
        }
    }

    public void UpdateBordersColor()
    {
        for (int i = 0; i < borders.Count; i++)
        {
            if (imageComponent[i].color == lockedColor || skillTree[i].abilityPointsCost > PlayerLevel.instance.AbilityPoints)
            {
                borders[i].color = unavialableColor;
            }
            if (imageComponent[i].color == defaultColor && skillTree[i].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
            {
                borders[i].color = avialableColor;
            }
            if (imageComponent[i].color == completedColor)
            {
                borders[i].color = fulledColor;
            }
        }
    }
}
